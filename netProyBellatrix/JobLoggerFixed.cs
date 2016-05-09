using System;
using System.Linq;
using System.Text;

public enum TypeMessage
{
    message = 1,
    warning = 2,
    error = 3,
}

public class JobLoggerFixed
{
    private static bool _logToFile;
    private static bool _logToConsole;
    private static bool _logToDatabase;
    private static TypeMessage _typeMessage;
    private bool _initialized;
    public JobLoggerFixed(bool logToFile, bool logToConsole, bool logToDatabase, TypeMessage typemessage)
    {
        _typeMessage = typemessage;
        _logToDatabase = logToDatabase;
        _logToFile = logToFile;
        _logToConsole = logToConsole;
    }

    public static void LogMessage(string message, TypeMessage typemessage)
    {
        try
        {
            message.Trim();
            if (message == null || message.Length == 0)
            {
                return;
            }
            if (!_logToConsole && !_logToFile && !_logToDatabase)
            {
                throw new Exception("Please indicate in the config, how to log: file, console or database ");
            }

            if (typemessage >= _typeMessage)
            {
                if (_logToDatabase)
                {
                    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
                    {
                        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("p_Add_LogValues", con))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("@message", System.Data.SqlDbType.VarChar).Value = message;
                            cmd.Parameters.Add("@typemessage", System.Data.SqlDbType.Int).Value = typemessage;
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }


                if (_logToFile)
                {
                    string sLogFileDirectory = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];
                    string sNameLogFile = System.Configuration.ConfigurationManager.AppSettings["NameLogFile"];
                    System.IO.StreamWriter sw = System.IO.File.AppendText(sLogFileDirectory + sNameLogFile + ".txt");
                    try
                    {
                        string logLine = DateTime.Now.ToShortDateString() + message;
                        sw.WriteLine(logLine);
                    }
                    finally
                    {
                        sw.Close();
                    }
                }

                if (_logToConsole)
                {
                    switch (typemessage)
                    {
                        case TypeMessage.error:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case TypeMessage.warning:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case TypeMessage.message:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(DateTime.Now.ToShortDateString() + message);
                }

            }
        }
        catch (Exception ex)
        {
            sendEmailEveryNminutes(ex);
        }
    }

    private static void sendEmailEveryNminutes(Exception ex)
    {
        try
        {
            //HERE THE CODE FOR SEND AN EMAIL EVERY N MINUTES 
        }
        catch 
        {
            
        }
    }
}