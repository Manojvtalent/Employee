using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebAPI_Project.Filters
{
    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static string ErrorlineNo, Errormsg, extype, ErrorLocation;

        public static void SendErrorToExt(Exception ex)
        {

            var line = Environment.NewLine + Environment.NewLine;

            ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            ErrorLocation = ex.Message.ToString();

            try
            {

                System.IO.Directory.GetCurrentDirectory();
                string filepath = Path.GetFullPath("ErrorLogFile/"); //Text file path

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                filepath = filepath + "ErrorLog-" + DateTime.Today.ToString("dd-mm-yy") + ".txt";   //Text File Name 
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date : " + " " + DateTime.Now.ToString() + line + " Error line No : " + ErrorlineNo + line + " Error Message : " + Errormsg + line + " Error type : " + extype + line + " Error Location : " + ErrorLocation;

                    sw.WriteLine("---------------------Exception Details  on  " + " " + DateTime.Now.ToString() + "----------------------");
                    sw.WriteLine("------------------------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("----------------------------------------------------*End---------------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();


                }

            }
            catch (Exception e)
            {
                e.ToString();
            }

        }

        public override void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            //Logging Exception into aText File 
            SendErrorToExt(ex);

            context.Result = new ObjectResult(ex.Message)
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;


        }

    }
}

