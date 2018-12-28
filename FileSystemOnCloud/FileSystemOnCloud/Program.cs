using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemOnCloud.function;

namespace FileSystemOnCloud
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //create_bucket.CreateBucket("lexsming");
            //file_delete.DeleteObject("lexsming");
            create_empty_folder.CreateEmptyFolder("lexsming");
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
        }
    }
}

