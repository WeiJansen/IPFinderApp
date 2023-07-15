using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IPFinderApp
{
    public partial class Form1 : Form
    {

        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        Dictionary<string, string> HostnameDic = new Dictionary<string, string>() {
            { "DESKTOP-QV1KSBT", "减肥中请勿打扰，富婆除外"},
            { "YUGUIQING", "尊贵的帕萨特车主兼老色批"},
            { "LAPTOP-JFF6OAL1", "207最帅最苗条小伙"}
        };

        public int ScanerTotal { get; set; }

        public Form1()
        {
            InitializeComponent();
            ScanerTotal = 0;
        }

        /// <summary>
        /// 获取ip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetButton_Click(object sender, EventArgs e)
        {
            if (!IsLocalConnection())
            {
                MessageBox.Show("电脑没连网");
                return;
            }

            if (ScanerTotal != 0 && ScanerTotal < 253)
            {
                MessageBox.Show("还没扫描完呢！！！");
                return;
            }
            ScanerTotal = 0;

            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            string address = GetGateWayAddress();
            this.gatewayTextBox.Text = address;
            // 本机ip
            string myIPAddress = GetLoaclIPAddress();
            this.myIPTextBox.Text = myIPAddress;
            if (string.IsNullOrEmpty(myIPAddress))
            {
                MessageBox.Show("IP获取失败，请检测网络连接");
                return;
            }
            // 截取网络分段
            string subnet = myIPAddress.ToString().Substring(0, myIPAddress.ToString().LastIndexOf('.'));
            // 清空上一次显示
            ipListView.Items.Clear();
            Task task = new Task(() =>
            {
                for (int i = 1; i < 255; i++)
                {
                    string ip = subnet + "." + i.ToString();
                    Ping ping = new Ping();
                    ping.PingCompleted += Ping_PingCompleted;
                    ping.SendAsync(ip, 50);
                }

            });
            // 启动线程
            task.Start();

        }


        // 获取本机ip
        private string GetLoaclIPAddress()
        {
            string ipAddress = GetLocalIPAddressByExternal();
            // 如果外网获取失败则通过本地网卡获取
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = GetLoaclIPAddressByNetworkInterface();
            }
            return ipAddress;
        }

        /// <summary>
        /// 遍历本地网卡获取本地ip
        /// </summary>
        /// <returns></returns>
        private string GetLoaclIPAddressByNetworkInterface()
        {
            string ipAddress = "";
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.Speed < 0)
                {
                    // 当前网卡没有网络连接，跳过
                    continue;
                }
                string lowerDesc = ni.Description.ToLower();

                // 排除虚拟网卡和vpn
                NetworkInterfaceType networkInterfaceType = ni.NetworkInterfaceType;
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
                    lowerDesc.Contains("virtual")
                    || lowerDesc.Contains("vmware")
                    || lowerDesc.Contains("vpn"))
                {
                    continue;
                }

                // 判断是不是无线网络连接
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    IPInterfaceProperties ipProps = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = addr.Address.ToString();
                            break;
                        }
                    }
                }

                // 判断有没有包含物理硬件关键词 pcie 或 intel 或 Realtek
                if (lowerDesc.Contains("pcie")
                    || lowerDesc.Contains("intel")
                    || lowerDesc.Contains("realtek"))
                {
                    IPInterfaceProperties ipProps = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = addr.Address.ToString();
                            break;
                        }
                    }
                }
            }
            return ipAddress;
        }


        /// <summary>
        /// 通过套接字连接外部网络确认
        /// </summary>
        /// <returns></returns>
        private string GetLocalIPAddressByExternal()
        {
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("114.114.114.114", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }




        /// <summary>
        /// 异步ping完成回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ping_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            ScanerTotal++;
            PingReply reply = e.Reply;
            if (reply.Status == IPStatus.Success)
            {
                string ip = reply.Address.ToString();
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(ip);
                    Console.WriteLine("IP Address: {0}, Hostname: {1}", ip, host.HostName);
                    // MessageBox.Show(ip + " - " + host.HostName);
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        string hostName = host.HostName;

                        ipListView.BeginUpdate();
                        if (HostnameDic.ContainsKey(hostName))
                        {
                            hostName = this.HostnameDic[hostName];
                            ipListView.Items.Insert(0, hostName + " - " + ip);
                        }
                        else
                        {
                            ipListView.Items.Add(hostName + " - " + ip);
                        }
                        ipListView.EndUpdate();
                    });
                    this.BeginInvoke(mi);
                }
                catch (SocketException)
                {
                    Console.WriteLine("IP Address: {0}, Hostname: <unknown>", ip);
                }
            }
        }




        /// <summary>
        /// 判断是否有网
        /// </summary>
        /// <returns></returns>
        public static bool IsLocalConnection()
        {
            int connectionDescription = 0;
            return InternetGetConnectedState(out connectionDescription, 0);
        }


        /// <summary>
        /// 获取网关地址
        /// </summary>
        /// <returns></returns>
        static string GetGateWayAddress()
        {
            ManagementObjectCollection moc = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (PropertyData p in mo.Properties)
                {
                    if (p.Name.Equals("DefaultIPGateway") && (p.Value != null))
                    {
                        string[] strs = p.Value as string[];

                        string[] gatewayArray = strs;
                        int index = 0;
                        while (index < gatewayArray.Length)
                        {
                            return gatewayArray[index];
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 复制listView中选择的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListView.SelectedListViewItemCollection selectedItems = this.ipListView.SelectedItems;

            if(null != selectedItems && selectedItems.Count > 0)
            {
                string content = selectedItems[0].Text;
                Clipboard.SetText(content);
            }

        }
    }
}
