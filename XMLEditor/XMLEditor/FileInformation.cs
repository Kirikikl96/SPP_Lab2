using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLEditor
{
    class FileInformation
    {
        public string filePath { get; set; }

        public string fileName {
            get
            {
                return System.IO.Path.GetFileName(this.filePath);
            }
        }

        public bool isSave { get; set; }

        public XmlDocument Document { get; set; }

        public FileInformation(string path)
        {
            this.filePath = path;
            this.isSave = true;
        }
    }
}
