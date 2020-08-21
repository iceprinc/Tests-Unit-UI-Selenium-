using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ReportViewer
    {
        public int UsedSize { get; set; }
        public void Clean(string dir)
        {
            try
            {
                UsedSize = new FileService().RemoveTemporaryFiles(dir);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
