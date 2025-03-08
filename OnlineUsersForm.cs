using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Timers;
using Newtonsoft.Json;

namespace DocumentosOrtobio
{
    public partial class OnlineUsersForm : Form
    {
        private List<UserLoginDetail> currentUserDetails;
        private Dictionary<string, bool> userLoginStatus;
        private readonly string basePath = @"\\D4MDP574\Doc Viewer$\Banco de dados";
        private System.Timers.Timer updateTimer;
        private System.Timers.Timer checkLogoutTimer;

        public OnlineUsersForm()
        {
            InitializeComponent();
            LoadCurrentUserDetails();
            LoadUserLoginStatus();
            PopulateOnlineUsersList();

            updateTimer = new System.Timers.Timer(1000); // Atualiza a cada segundo
            updateTimer.Elapsed += UpdateTimer_Elapsed;
            updateTimer.Start();

            checkLogoutTimer = new System.Timers.Timer(5000); // Verifica logout a cada 5 segundos
            checkLogoutTimer.Elapsed += CheckLogoutTimer_Elapsed;
            checkLogoutTimer.Start();
        }

        private void LoadCurrentUserDetails()
        {
            string currentUserDetailsFilePath = Path.Combine(basePath, "currentUsers.json");

            if (File.Exists(currentUserDetailsFilePath))
            {
                currentUserDetails = JsonConvert.DeserializeObject<List<UserLoginDetail>>(File.ReadAllText(currentUserDetailsFilePath));
            }
            else
            {
                currentUserDetails = new List<UserLoginDetail>();
            }
        }

        private void LoadUserLoginStatus()
        {
            string userLoginStatusFilePath = Path.Combine(basePath, "userLoginStatus.json");

            if (File.Exists(userLoginStatusFilePath))
            {
                userLoginStatus = JsonConvert.DeserializeObject<Dictionary<string, bool>>(File.ReadAllText(userLoginStatusFilePath));
            }
            else
            {
                userLoginStatus = new Dictionary<string, bool>();
            }
        }

        private void PopulateOnlineUsersList()
        {
            listBoxOnlineUsers.Items.Clear();
            foreach (var user in currentUserDetails)
            {
                var onlineTime = (DateTime.Now - DateTime.ParseExact(user.LoginTime, "dd-MM-yyyy HH:mm:ss", null)).ToString(@"hh\:mm\:ss");
                listBoxOnlineUsers.Items.Add($"{user.Username}, {user.IPAddress}, {user.LoginTime}, {onlineTime}");
            }
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(PopulateOnlineUsersList));
            }
            else
            {
                PopulateOnlineUsersList();
            }
        }

        private void CheckLogoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LoadUserLoginStatus();

            var usersToRemove = currentUserDetails.Where(u => userLoginStatus.ContainsKey(u.Username) && !userLoginStatus[u.Username]).ToList();

            if (usersToRemove.Any())
            {
                foreach (var userDetail in usersToRemove)
                {
                    userDetail.OnlineTime = (DateTime.Now - DateTime.ParseExact(userDetail.LoginTime, "dd-MM-yyyy HH:mm:ss", null)).ToString(@"hh\:mm\:ss");
                    SaveUserLoginDetails(userDetail);
                    currentUserDetails.Remove(userDetail);
                }
                SaveCurrentUserDetails();
                if (InvokeRequired)
                {
                    Invoke(new Action(PopulateOnlineUsersList));
                }
                else
                {
                    PopulateOnlineUsersList();
                }
            }
        }

        private void SaveCurrentUserDetails()
        {
            string currentUserDetailsFilePath = Path.Combine(basePath, "currentUsers.json");
            File.WriteAllText(currentUserDetailsFilePath, JsonConvert.SerializeObject(currentUserDetails, Formatting.Indented));
        }

        private void SaveUserLoginDetails(UserLoginDetail userDetail)
        {
            string userLoginDetailsFilePath = Path.Combine(basePath, "userLoginDetails.json");
            var userLoginDetails = File.Exists(userLoginDetailsFilePath)
                ? JsonConvert.DeserializeObject<List<UserLoginDetail>>(File.ReadAllText(userLoginDetailsFilePath))
                : new List<UserLoginDetail>();

            userLoginDetails.Add(userDetail);

            File.WriteAllText(userLoginDetailsFilePath, JsonConvert.SerializeObject(userLoginDetails, Formatting.Indented));
        }

        private void LogActivity(string activity)
        {
            string logMessage = $"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - {GetLocalIPAddress()} - {Environment.UserName} - {activity}{Environment.NewLine}";
            File.AppendAllText("activity_log.txt", logMessage);
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Local IP Address Not Found!";
        }

        private void listBoxOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementação necessária
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            updateTimer.Stop();
            updateTimer.Dispose();
            checkLogoutTimer.Stop();
            checkLogoutTimer.Dispose();
            base.OnFormClosing(e);

            // Não fecha o aplicativo inteiro
            // Application.Exit();
        }

        private void BtnLogoutUser_Click(object sender, EventArgs e)
        {
            // Implementação necessária
        }
    }
}