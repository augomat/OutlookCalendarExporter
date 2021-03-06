﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OutlookCalendarExporter
{
    class FTPSingleFileUploader
    {
        protected string Host;
        protected string User;
        protected string Password;
        protected string Directory;
        protected string Filename;

        protected string HttpDirectory;
        protected string HttpFilename;

       public void setFtpHostAndCredentials(string host, string user, string password)
        {
            Host = host;
            User = user;
            Password = password;
        }

        public void setFtpPath(string directory, string filename)
        {
            Directory = directory;
            Filename = filename;
        }

        public void setHttpPath(string directory, string filename)
        {
            HttpDirectory = directory;
            HttpFilename = filename;
        }

        protected bool isConfigurationSufficient()
        {
            if (Host.Length == 0 || User.Length == 0 || Password.Length == 0 || Filename.Length == 0)
                return false;
            else
                return true;
        }

        public void upload(string data)
        {
            if (!isConfigurationSufficient())
                throw new Exception("Configuration of FTP-Uploader is not sufficient");

            //CheckHostAvailability(Host);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Host + '/' + Directory + '/' + Filename);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(User, Password);

            using (Stream requestStream = request.GetRequestStream())
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] icalByteArray = encoding.GetBytes(data);
                requestStream.Write(icalByteArray, 0, data.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != FtpStatusCode.ClosingData)
                    throw new Exception("FTP-Upload failed: " + response.StatusDescription);
            }
        }

        public void CheckHostAvailability(String Host)
        {
            var pinger = new Ping();
            var reply = pinger.Send(Host);

            if (reply.Status != IPStatus.Success)
                throw new Exception("Host unreachable");
        }

        public string getHttpLink()
        {
            return HttpDirectory + '/' + HttpFilename;;
        }

        /*
         * Just for testing
         */
        public void writeToLocalFile(string icalString)
        {
            System.IO.File.WriteAllText(Filename, icalString);
        }
    }
}
