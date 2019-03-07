using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace REGISTRATIONAPP
{
    public class Registration
    {
        const string NAME_FILE = "USERS.xml";
            

        public void Registr(User user)
        {
            
            //User user = new User();
            XDocument doc = XDocument.Load(NAME_FILE);

            doc.Root.Add(new XElement("User",
                new XElement("Email", user.Email),
                new XElement("Phone", user.Phone ),
                new XElement("Password", user.Password),
                new XElement("City", user.City),
                new XElement("Age", user.Age.ToString())));

            doc.Save(NAME_FILE);

        }

        public void CreateXML()
        {
            User user = new User();
            XDocument doc = new XDocument(new XElement("Users"));
            doc.Save(NAME_FILE);
        }
    }
}
