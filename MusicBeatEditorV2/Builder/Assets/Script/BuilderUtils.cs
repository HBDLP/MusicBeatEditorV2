using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class BuilderUtils
{
    public static int GCD(int a, int b)//最大公约数 
    {
        if (a < b) { a = a + b; b = a - b; a = a - b; }
        return (a % b == 0) ? b : GCD(a % b, b);
    }

    public static int LCM(int a, int b)//最小公倍数 
    {
        return a * b / GCD(a, b);
    }

    public static string GetSvnUsername()
    {
        string username = "unknow";
        string romingUrl = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        string svnUrl = Path.Combine(romingUrl, "Subversion\\auth\\svn.simple");
        if (Directory.Exists(svnUrl))
        {
            string[] filesAry = Directory.GetFiles(svnUrl);
            if (filesAry.Length > 0)
            {
                string last = filesAry[0];
                DateTime dt = File.GetLastAccessTime(last);
                for (int i = 0; i < filesAry.Length; ++i)
                {
                    string file = filesAry[i];
                    DateTime dt2 = File.GetLastAccessTime(file);
                    if (dt2 > dt)
                    {
                        dt = dt2;
                        last = file;
                    }
                }
                //最后修改的文件
                //UnityEngine.Debug.Log(last);
                //UnityEngine.Debug.Log(dt);

                string[] linesContent = File.ReadAllLines(last);
                for (int i = 0; i < linesContent.Length; ++i)
                {
                    string line = linesContent[i];
                    if (line.Equals("username"))
                    {
                        int j = i + 2;
                        if (j < linesContent.Length)
                        {
                            username = linesContent[j];
                        }
                    }
                }

            }
        }

        return username;
    }

    public static Int64 GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds);
    }

    public static string GetMD5(byte[] ary)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] retVal = md5.ComputeHash(ary);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < retVal.Length; i++)
        {
            sb.Append(retVal[i].ToString("x2"));
        }
        return sb.ToString();
    }

    public static string GetStringMD5(string content)
    {
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(content);
        return GetMD5(bs);
    }
}
