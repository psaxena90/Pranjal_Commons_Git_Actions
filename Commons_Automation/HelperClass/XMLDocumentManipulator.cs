using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Commons_Automation
{

    public enum XMLFileName
    {
        LoginPage,
        LandingPage,
        CardHolders,
        CardHolderDetails,
        Location,
        ProgramDetails,
        ProgramSearch,
        Reports,
        SubPrograms,
        Tools,
        MyAccount,
        UserManagement,
        ApplURL
    }

    public class XMLDocumentManipulator
    {
        // static NCU_LandingPage nc = new NCU_LandingPage();

       // PageServices ps=new PageServices();
        public static string ServerLocation
        {
            get
            {
                if (!object.Equals(ConfigurationManager.AppSettings["ServerPath"], null))
                {
                    return ConfigurationManager.AppSettings["ServerPath"].Trim();
                }
                else
                {
                    return "";
                }
            }
        }

        public  XmlNodeList GetNodeList(string xPath, XMLFileName FileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList xmlNodeList = null;
            FileStream fileStream = null;

            fileStream = new FileStream(GetXmlFilePath(FileName), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            xmlDoc.Load(fileStream);

            xmlNodeList = xmlDoc.SelectNodes(xPath);

            fileStream.Close();
            xmlDoc = null;

            return xmlNodeList;
        }

        public string GetNodeValue(string xPath, XMLFileName FileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string xmlNodeValue = "";
            XmlNode xmlNode = null;
            FileStream fileStream = null;

            fileStream = new FileStream(GetXmlFilePath(FileName), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            xmlDoc.Load(fileStream);

            xmlNode = xmlDoc.SelectSingleNode(xPath);

            if (!object.Equals(xmlNode, null))
            {
                xmlNodeValue = xmlNode.InnerText;
            }
            else
            {
                xmlNodeValue = "";
            }

            fileStream.Close();
            xmlDoc = null;

            return xmlNodeValue;
        }

        public  string[] GetNodesValue(string xPath, XMLFileName FileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string[] xmlNodesValue = { "" };
            XmlNodeList xmlNodeList = null;
            FileStream fileStream = null;

            fileStream = new FileStream(GetXmlFilePath(FileName), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            xmlDoc.Load(fileStream);

            xmlNodeList = xmlDoc.SelectNodes(xPath);

            if (!object.Equals(xmlNodeList, null))
            {
                xmlNodesValue = new string[xmlNodeList.Count];

                for (int loginCounter = 0; loginCounter < xmlNodeList.Count; loginCounter++)
                {
                    XmlNode xmlNode = xmlNodeList[loginCounter];

                    xmlNodesValue[loginCounter] = xmlNode.InnerText;
                }
            }

            fileStream.Close();
            xmlDoc = null;

            return xmlNodesValue;
        }

        private  string GetXmlFilePath(XMLFileName FileName)
        {
            string xmlDocumentFileURL = "";

            string inputXMLDataFileDirectoryPath = PageServices.GetProjectPath() + ConfigurationManager.AppSettings["InputXMLDataFileDirectoryPath"].Trim();

            if (XMLFileName.LoginPage.Equals(FileName))
            {
                xmlDocumentFileURL = inputXMLDataFileDirectoryPath + ConfigurationManager.AppSettings["XMLLoginPageFilePath"].Trim();
            }
            else if (XMLFileName.LandingPage.Equals(FileName))
            {
                xmlDocumentFileURL = inputXMLDataFileDirectoryPath + ConfigurationManager.AppSettings["XMLLandingPageFilePath"].Trim();
            }
           
            else if (XMLFileName.ApplURL.Equals(FileName))
            {
                xmlDocumentFileURL = inputXMLDataFileDirectoryPath + ConfigurationManager.AppSettings["XMLApplURLFilePath"].Trim();
            }
            else
            {
                xmlDocumentFileURL = "";
            }

            return xmlDocumentFileURL;
        }
    }
}
