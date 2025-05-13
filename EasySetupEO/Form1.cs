using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace easysetup
{
    public partial class mainwindow : Form
    {
        public mainwindow()
        {
            InitializeComponent();
        }

        private void mainwindow_Load(object sender, EventArgs e)
        {
            LoadServerName();
            LoadServerIP();
            LoadLoginPort();
            LoadNpcPort();
            LoadMsgPort();
            LoadDatabaseConfig();
        }

        #region Loading Methods

        private void LoadServerName()
        {
            string filePath = Path.Combine(Application.StartupPath, "AccountServer", "account.ini");
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    if (line.Trim().StartsWith("SERVERNAME="))
                    {
                        txtServerName.Text = line.Substring("SERVERNAME=".Length).Trim();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("The file account.ini was not found in the AccountServer folder.",
                                "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadServerIP()
        {
            string filePath = Path.Combine(Application.StartupPath, "AccountServer", "config.ini");
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    if (line.Trim().StartsWith("SERVERIP"))
                    {
                        var parts = line.Split('=');
                        if (parts.Length > 1)
                        {
                            txtServerIP.Text = parts[1].Trim();
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The file config.ini was not found in the AccountServer folder.",
                                "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadLoginPort()
        {
            string filePath = Path.Combine(Application.StartupPath, "AccountServer", "config.ini");
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    if (line.Trim().StartsWith("LOGINLISTENPORT"))
                    {
                        var parts = line.Split('=');
                        if (parts.Length > 1)
                        {
                            txtloginport.Text = parts[1].Trim();
                            break;
                        }
                    }
                }
            }
        }

        private void LoadNpcPort()
        {
            string filePath = Path.Combine(Application.StartupPath, "AccountServer", "config.ini");
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    if (line.Trim().StartsWith("POINTLISTENPORT"))
                    {
                        var parts = line.Split('=');
                        if (parts.Length > 1)
                        {
                            txtnpcport.Text = parts[1].Trim();
                            break;
                        }
                    }
                }
            }
        }

        private void LoadMsgPort()
        {
            string filePath = Path.Combine(Application.StartupPath, "GameServer", "config.ini");
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    if (line.Trim().StartsWith("GAMESERVER_PORT"))
                    {
                        var parts = line.Split('=');
                        if (parts.Length > 1)
                        {
                            txtmsgport.Text = parts[1].Trim();
                            break;
                        }
                    }
                }
            }
        }

        // Load database configuration values from AccountServer\config.ini
        private void LoadDatabaseConfig()
        {
            string filePath = Path.Combine(Application.StartupPath, "AccountServer", "config.ini");
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string trimmedLine = line.Trim();
                    if (trimmedLine.StartsWith("DATABASENAME="))
                    {
                        txtdbname.Text = trimmedLine.Substring("DATABASENAME=".Length).Trim();
                    }
                    else if (trimmedLine.StartsWith("DBUSER="))
                    {
                        txtdbuser.Text = trimmedLine.Substring("DBUSER=".Length).Trim();
                    }
                    else if (trimmedLine.StartsWith("DBPASSWORD="))
                    {
                        txtdbpass.Text = trimmedLine.Substring("DBPASSWORD=".Length).Trim();
                    }
                }
            }
            else
            {
                MessageBox.Show("The file config.ini was not found in the AccountServer folder.",
                                "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Save & Update Methods

        private void savebtn_Click(object sender, EventArgs e)
        {
            // Retrieve new values from textboxes
            string newServerName = txtServerName.Text.Trim();
            string newServerIP = txtServerIP.Text.Trim();
            string newLoginPort = txtloginport.Text.Trim();
            string newNpcPort = txtnpcport.Text.Trim();
            string newMsgPort = txtmsgport.Text.Trim();

            // Database values from DB textboxes
            string newDBName = txtdbname.Text.Trim();
            string newDBUser = txtdbuser.Text.Trim();
            string newDBPass = txtdbpass.Text.Trim();

            if (string.IsNullOrEmpty(newServerName))
            {
                MessageBox.Show("Server name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(newServerIP))
            {
                MessageBox.Show("Server IP cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- AccountServer Folder Updates ---
            // Update account.ini: update SERVER_TITLE, SERVERNAME, and database credentials (LOGINNAME, PASSWORD)
            string accountIniPath = Path.Combine(Application.StartupPath, "AccountServer", "account.ini");
            UpdateFileKey(accountIniPath, new string[] { "SERVER_TITLE", "SERVERNAME" }, newServerName);
            UpdateFileKey(accountIniPath, new string[] { "LOGINNAME" }, newDBUser);
            UpdateFileKey(accountIniPath, new string[] { "PASSWORD" }, newDBPass);

            // Update AuthorizeDB.cfg: update first line's tokens and third line's last token with DB name
            string authDbCfgPath = Path.Combine(Application.StartupPath, "AccountServer", "AuthorizeDB.cfg");
            UpdateAuthorizeDBCfg(authDbCfgPath, newDBUser, newDBPass, newDBName);

            // Update AccountServer\config.ini for DB keys and server settings
            string accountConfigPath = Path.Combine(Application.StartupPath, "AccountServer", "config.ini");
            UpdateFileKey(accountConfigPath, new string[] { "SERVER_TITLE", "SERVERNAME" }, newServerName);
            UpdateFileKey(accountConfigPath, new string[] { "SERVERIP" }, newServerIP);
            UpdateFileKey(accountConfigPath, new string[] { "LOGINLISTENPORT" }, newLoginPort);
            UpdateFileKey(accountConfigPath, new string[] { "POINTLISTENPORT" }, newNpcPort);
            UpdateFileKey(accountConfigPath, new string[] { "DATABASENAME" }, newDBName);
            UpdateFileKey(accountConfigPath, new string[] { "DBUSER" }, newDBUser);
            UpdateFileKey(accountConfigPath, new string[] { "DBPASSWORD" }, newDBPass);

            // **New Update for AccountServer\gameserver.cfg**
            // Update the file (similar to the one in GameServer folder) to update DB credentials.
            string accountGameserverCfgPath = Path.Combine(Application.StartupPath, "AccountServer", "gameserver.cfg");
            UpdateGameserverCfg(accountGameserverCfgPath, newDBUser, newDBPass, newDBName);

            // --- GameServer Folder Updates ---
            // Update GameServer\config.ini for DB keys and message port
            string gameConfigPath = Path.Combine(Application.StartupPath, "GameServer", "config.ini");
            UpdateFileKey(gameConfigPath, new string[] { "SERVER_TITLE", "SERVERNAME" }, newServerName);
            UpdateFileKey(gameConfigPath, new string[] { "GAMESERVER_PORT" }, newMsgPort);
            UpdateFileKey(gameConfigPath, new string[] { "DB_USER" }, newDBUser);
            UpdateFileKey(gameConfigPath, new string[] { "DB_PW" }, newDBPass);
            UpdateFileKey(gameConfigPath, new string[] { "DB_NAME" }, newDBName);

            // Update GameServer\gameserver.cfg for DB credentials (last three tokens)
            string gameserverCfgPath = Path.Combine(Application.StartupPath, "GameServer", "gameserver.cfg");
            UpdateGameserverCfg(gameserverCfgPath, newDBUser, newDBPass, newDBName);

            // Update GameServer\shell.ini for server settings and DB keys (including LOGINNAME and PASSWORD)
            string shellIniPath = Path.Combine(Application.StartupPath, "GameServer", "shell.ini");
            UpdateFileKey(shellIniPath, new string[] { "SERVERNAME" }, newServerName);
            UpdateFileKey(shellIniPath, new string[] { "ACCOUNT_IP" }, newServerIP);
            UpdateFileKey(shellIniPath, new string[] { "ACCOUNT_PORT" }, newNpcPort);
            UpdateFileKey(shellIniPath, new string[] { "DB_USER" }, newDBUser);
            UpdateFileKey(shellIniPath, new string[] { "DB_PW" }, newDBPass);
            UpdateFileKey(shellIniPath, new string[] { "DB_DB" }, newDBName);
            UpdateFileKey(shellIniPath, new string[] { "DB_NAME" }, newDBName);
            // Also update LOGINNAME and PASSWORD in shell.ini
            UpdateFileKey(shellIniPath, new string[] { "LOGINNAME" }, newDBUser);
            UpdateFileKey(shellIniPath, new string[] { "PASSWORD" }, newDBPass);

            // --- Other Conversions ---
            ConvertShellIniToDat(newDBUser, newDBPass);
            UpdatePortDat(newMsgPort);

            MessageBox.Show("Server and Database configuration updated and files converted successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Helper Methods

        // Update lines in a file that start with any of the specified keys.
        private void UpdateFileKey(string filePath, string[] keys, string newValue)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    foreach (var key in keys)
                    {
                        if (lines[i].TrimStart().StartsWith(key))
                        {
                            int index = lines[i].IndexOf("=");
                            if (index != -1)
                            {
                                string leftPart = lines[i].Substring(0, index + 1);
                                lines[i] = leftPart + " " + newValue;
                            }
                        }
                    }
                }
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                MessageBox.Show($"The file {filePath} was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Update AuthorizeDB.cfg: Update the first line's tokens (after IP) and the third line's last token.
        private void UpdateAuthorizeDBCfg(string filePath, string dbUser, string dbPass, string dbName)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    string[] tokens = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length >= 4)
                    {
                        tokens[1] = dbUser;
                        tokens[2] = dbPass;
                        tokens[3] = dbName;
                        lines[0] = string.Join(" ", tokens);
                    }
                }
                if (lines.Length >= 3)
                {
                    string[] tokens = lines[2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length >= 1)
                    {
                        tokens[tokens.Length - 1] = dbName;
                        lines[2] = string.Join(" ", tokens);
                    }
                }
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                MessageBox.Show($"The file {filePath} was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Update gameserver.cfg: For each line, assume the last three tokens are DB credentials and update them.
        private void UpdateGameserverCfg(string filePath, string dbUser, string dbPass, string dbName)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] tokens = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length >= 3)
                    {
                        tokens[tokens.Length - 3] = dbUser;
                        tokens[tokens.Length - 2] = dbPass;
                        tokens[tokens.Length - 1] = dbName;
                        lines[i] = string.Join(" ", tokens);
                    }
                }
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                MessageBox.Show($"The file {filePath} was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Convert shell.ini to shell.dat using the provided method.
        // The account port is taken from the NPC port textbox.
        private void ConvertShellIniToDat(string LoginName, string PassWord)
        {
            string datFilePath = Path.Combine(Application.StartupPath, "GameServer", "shell.dat");
            string accountIp = txtServerIP.Text.Trim();
            string serverName = txtServerName.Text.Trim();
            string loginName = LoginName;
            string password = PassWord;
            int accountPort;
            if (!int.TryParse(txtnpcport.Text.Trim(), out accountPort))
            {
                accountPort = 6130;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(datFilePath, FileMode.Create)))
            {
                WritePaddedString(writer, accountIp, 16);
                WritePaddedString(writer, serverName, 16);
                WritePaddedString(writer, loginName, 16);
                WritePaddedString(writer, password, 16);
                writer.Write(accountPort);

                long currentSize = writer.BaseStream.Length;
                long paddingNeeded = 72 - currentSize;
                if (paddingNeeded > 0)
                {
                    writer.Write(new byte[paddingNeeded]);
                }
            }
        }

        // Update port.dat (located in GameServer) with the new message port as plain text.
        private void UpdatePortDat(string msgPort)
        {
            string portDatPath = Path.Combine(Application.StartupPath, "GameServer", "port.dat");
            File.WriteAllText(portDatPath, msgPort);
        }

        private void WritePaddedString(BinaryWriter writer, string value, int length)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(value);
            writer.Write(bytes);
            writer.Write(new byte[length - bytes.Length]);
        }

        private void btncrtoem_Click(object sender, EventArgs e)
        {
            // Retrieve values from the textboxes.
            string serverName = txtServerName.Text.Trim();
            string serverIP = txtServerIP.Text.Trim();
            string loginPort = txtloginport.Text.Trim();

            if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(serverIP) || string.IsNullOrEmpty(loginPort))
            {
                MessageBox.Show("Please ensure Server Name, Server IP, and Login Port are filled.",
                                "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build the IP:Port string.
            string ipPort = serverIP + ":" + loginPort;

            // Construct the content for oem.dat.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[Oem]");
            sb.AppendLine("Id=2010");
            sb.AppendLine();
            sb.AppendLine("[AccountSetup]");
            sb.AppendLine("Type=1");
            sb.AppendLine();
            sb.AppendLine("[ServerInfo]");
            sb.AppendLine("URL=null");
            sb.AppendLine();
            sb.AppendLine("[ServerStatus]");
            sb.AppendLine("Link=null");
            sb.AppendLine();
            sb.AppendLine("[Header]");
            sb.AppendLine("GroupAmount=1");
            sb.AppendLine("Group1=" + serverName);
            sb.AppendLine();
            sb.AppendLine("[Group1]");
            sb.AppendLine("ServerAmount=1");
            sb.AppendLine();
            sb.AppendLine("Server1=" + serverName);
            sb.AppendLine("Ip1=" + ipPort);
            sb.AppendLine("Pic1=Server1");
            sb.AppendLine("ServerName1=" + serverName);

            // Write the content to oem.dat in the application's startup directory.
            string oemDatPath = Path.Combine(Application.StartupPath, "oem.dat");
            File.WriteAllText(oemDatPath, sb.ToString());

            MessageBox.Show("Oem.dat file created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        #endregion


        private void fbLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.facebook.com/profile.php?id=61554036273018",
                UseShellExecute = true
            });
        }
    }





}
