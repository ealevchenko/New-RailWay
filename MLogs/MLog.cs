﻿using MessageLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLog
{

    public static class MLog
    {
  
        // Вкл\Отк логирования в журналы Windows
        static bool _eLogs = false;
        static bool _eLogErrors = false;

        // Вкл\Отк логирования в базу данных
        static bool _dbLogs = false;
        static bool _dbLogErrors = false;

        // Вкл\Отк логирования в файл на диске
        static bool _fLogs = false;
        static bool _fLogErrors = false;

        static MLog()
        {
            FileLogs.InitLogger();
            try
            {
                _eLogs = bool.Parse(ConfigurationManager.AppSettings["Logs"].ToString());
                _eLogErrors = bool.Parse(ConfigurationManager.AppSettings["LogErrors"].ToString());
                _dbLogs = bool.Parse(ConfigurationManager.AppSettings["dbLogs"].ToString());
                _dbLogErrors = bool.Parse(ConfigurationManager.AppSettings["dbLogErrors"].ToString());
                _fLogs = bool.Parse(ConfigurationManager.AppSettings["fLogs"].ToString());
                _fLogErrors = bool.Parse(ConfigurationManager.AppSettings["fLogErrors"].ToString());
                //LogError(new Exception(), String.Format("Ок чтения AppSettings:(Logs={0},LogErrors={1},dbLogs={2},dbLogErrors={3},fLogs={4},fLogErrors={5})", _eLogs,_eLogErrors,_dbLogs,_dbLogErrors,_fLogs,_fLogErrors));
            }
            catch (Exception e)
            {
                LogError(e, String.Format("Ошибка чтения AppSettings:(Logs,LogErrors,dbLogs,dbLogErrors,fLogs,fLogErrors)"));
            }
        }

        public static void InitRWLogs(bool eLogs, bool eLogErrors, bool dbLogs, bool dbLogErrors, bool fLogs, bool fLogErrors)
        {
            _eLogs = eLogs;
            _eLogErrors = eLogErrors;
            _dbLogs = dbLogs;
            _dbLogErrors = dbLogErrors;
            _fLogs = fLogs;
            _fLogErrors = fLogErrors;
        }

        public static void LogError(Exception e, string message)
        {
            Console.WriteLine(e.ToString());
            FileLogs.SaveError(message, e);
        }

        #region Information

        public static void WriteInformation(this string message, service service, eventID eventID, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveInformationToEventLogs(service, eventID);
            if (dblog) message.SaveInformationToDB(service, eventID);
            if (flog) message.SaveInformationToFile(service, eventID);
            Console.WriteLine(String.Format("\nservice: {0}\neventID: {1}\nInformation: {2}", service, eventID, message));
        }

        public static void WriteInformation(this string message, service service, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveInformationToEventLogs(service);
            if (dblog) message.SaveInformationToDB(service);
            if (flog) message.SaveInformationToFile(service);
            Console.WriteLine(String.Format("\nservice: {0}\nInformation: {1}", service, message));
        }

        public static void WriteInformation(this string message, eventID eventID, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveInformationToEventLogs(eventID);
            if (dblog) message.SaveInformationToDB(eventID);
            if (flog) message.SaveInformationToFile(eventID);
            Console.WriteLine(String.Format("\neventID: {0}\nInformation: {1}", eventID, message));
        }

        public static void WriteInformation(this string message, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveInformationToEventLogs();
            if (dblog) message.SaveInformationToDB();
            if (flog) message.SaveInformationToFile();
            Console.WriteLine(String.Format("\nInformation: {0}", message));
        }

        public static void WriteInformation(this string message, service service, eventID eventID)
        {
            WriteInformation(message, service, eventID, _eLogs, _dbLogs, _fLogs);
        }

        public static void WriteInformation(this string message, service service)
        {
            WriteInformation(message, service, _eLogs, _dbLogs, _fLogs);
        }

        public static void WriteInformation(this string message, eventID eventID)
        {
            WriteInformation(message,eventID, _eLogs, _dbLogs, _fLogs);
        }

        public static void WriteInformation(this string message)
        {
            WriteInformation(message,_eLogs, _dbLogs, _fLogs);
        }

        #endregion

        #region Warning

        public static void WriteWarning(this string message, service service, eventID eventID, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveWarningToEventLogs(service, eventID);
            if (dblog) message.SaveWarningToDB(service, eventID);
            if (flog) message.SaveWarningToFile(service, eventID);
            Console.WriteLine(String.Format("\nservice: {0}\neventID: {1}\nWarning: {2}", service, eventID, message));
        }

        public static void WriteWarning(this string message, service service, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveWarningToEventLogs(service);
            if (dblog) message.SaveWarningToDB(service);
            if (flog) message.SaveWarningToFile(service);
            Console.WriteLine(String.Format("\nservice: {0}\nWarning: {1}", service, message));
        }

        public static void WriteWarning(this string message, eventID eventID, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveWarningToEventLogs(eventID);
            if (dblog) message.SaveWarningToDB(eventID);
            if (flog) message.SaveWarningToFile(eventID);
            Console.WriteLine(String.Format("\neventID: {0}\nWarning: {1}", eventID, message));
        }

        public static void WriteWarning(this string message, bool elog, bool dblog, bool flog)
        {
            if (elog) message.SaveWarningToEventLogs();
            if (dblog) message.SaveWarningToDB();
            if (flog) message.SaveWarningToFile();
            Console.WriteLine(String.Format("\nWarning: {0}", message));
        }

        public static void WriteWarning(this string message, service service, eventID eventID)
        {
            WriteWarning(message,service, eventID, _eLogs, _dbLogs, _fLogs);
        }

        public static void WriteWarning(this string message, service service)
        {
            WriteWarning(message,service, _eLogs, _dbLogs, _fLogs);
        }

        public static void WriteWarning(this string message, eventID eventID)
        {
            WriteWarning(message,eventID, _eLogs, _dbLogs, _fLogs);
        }

        public static void WriteWarning(this string message)
        {
            WriteWarning(message,_eLogs, _dbLogs, _fLogs);
        }

        #endregion

        #region Error

        public static void WriteError(this string message, service service, eventID eventID, bool elog, bool dblog, bool flog)
        {
            //Console.WriteLine(String.Format("\nError: {0}", message));
            if (elog) message.SaveErrorToEventLogs(service, eventID);
            if (dblog) message.SaveErrorToDB(service, eventID);
            if (flog) message.SaveErrorToFile(service, eventID);
            Console.WriteLine(String.Format("\nservice: {0}\neventID: {1}\nError: {2}", service, eventID, message));
        }


        public static void WriteError(this string message, service service, bool elog, bool dblog, bool flog)
        {
            //Console.WriteLine(String.Format("\nError: {0}", message));            
            if (elog) message.SaveErrorToEventLogs(service);
            if (dblog) message.SaveErrorToDB(service);
            if (flog) message.SaveErrorToFile(service);
            Console.WriteLine(String.Format("\nservice: {0}\nError: {1}", service, message));
        }

        public static void WriteError(this string message, eventID eventID, bool elog, bool dblog, bool flog)
        {
            //Console.WriteLine(String.Format("\nError: {0}", message));              
            if (elog) message.SaveErrorToEventLogs(eventID);
            if (dblog) message.SaveErrorToDB(eventID);
            if (flog) message.SaveErrorToFile(eventID);
            Console.WriteLine(String.Format("\neventID: {0}\nError: {1}", eventID, message));
        }

        public static void WriteError(this string message, bool elog, bool dblog, bool flog)
        {
            //Console.WriteLine(String.Format("\nError: {0}", message));              
            if (elog) message.SaveErrorToEventLogs();
            if (dblog) message.SaveErrorToDB();
            if (flog) message.SaveErrorToFile();
            Console.WriteLine(String.Format("\nError: {0}", message));
        }

        public static void WriteError(this string message, service service, eventID eventID)
        {
            WriteError(message, service, eventID, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this string message, service service)
        {
            WriteError(message, service, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this string message, eventID eventID)
        {
            WriteError(message, eventID, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this string message)
        {
            WriteError(message, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        #endregion

        #region Exception

        public static void WriteError(this Exception ex, string message, service service, eventID eventID, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nMessage:{0}\nException{1}",message,ex.ToString()) );
            if (elog) ex.SaveErrorToEventLogs(message, service, eventID);
            if (dblog) ex.SaveErrorToDB(message, service, eventID);
            if (flog) ex.SaveErrorToFile(message, service, eventID);
        }

        public static void WriteError(this Exception ex, service service, eventID eventID, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nException{0}", ex.ToString()));
            if (elog) ex.SaveErrorToEventLogs(service, eventID);
            if (dblog) ex.SaveErrorToDB(service, eventID);
            if (flog) ex.SaveErrorToFile(service, eventID);
        }

        public static void WriteError(this Exception ex, string message, service service, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nMessage:{0}\nException{1}", message, ex.ToString()));
            if (elog) ex.SaveErrorToEventLogs(message, service);
            if (dblog) ex.SaveErrorToDB(message, service);
            if (flog) ex.SaveErrorToFile(message, service);
        }

        public static void WriteError(this Exception ex, service service, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nException{0}", ex.ToString()));
            if (elog) ex.SaveErrorToEventLogs(service);
            if (dblog) ex.SaveErrorToDB(service);
            if (flog) ex.SaveErrorToFile(service);
        }

        public static void WriteError(this Exception ex, string message, eventID eventID, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nMessage:{0}\nException{1}", message, ex.ToString()));
            if (elog) ex.SaveErrorToEventLogs(message, eventID);
            if (dblog) ex.SaveErrorToDB(message, eventID);
            if (flog) ex.SaveErrorToFile(message, eventID);
        }

        public static void WriteError(this Exception ex, eventID eventID, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nException{0}", ex.ToString()));
            if (elog) ex.SaveErrorToEventLogs(eventID);
            if (dblog) ex.SaveErrorToDB(eventID);
            if (flog) ex.SaveErrorToFile(eventID);
        }

        public static void WriteError(this Exception ex, string message, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nMessage:{0}\nException{1}", message, ex.ToString()));
            if (elog) ex.SaveErrorToEventLogs(message);
            if (dblog) ex.SaveErrorToDB(message);
            if (flog) ex.SaveErrorToFile(message);
        }

        public static void WriteError(this Exception ex, bool elog, bool dblog, bool flog)
        {
            Console.WriteLine(String.Format("\nException{0}", ex.ToString()));
            if (elog) ex.SaveErrorToEventLogs();
            if (dblog) ex.SaveErrorToDB();
            if (flog) ex.SaveErrorToFile();
        }

        public static void WriteError(this Exception ex, string message, service service, eventID eventID)
        {
            WriteError(ex, message, service, eventID, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this Exception ex, service service, eventID eventID)
        {
            WriteError(ex, service, eventID, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this Exception ex, string message, service service)
        {
            WriteError(ex, message, service, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this Exception ex, service service)
        {
            WriteError(ex, service, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this Exception ex, string message, eventID eventID)
        {
            WriteError(ex, message, eventID, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this Exception ex, eventID eventID)
        {
            WriteError(ex, eventID, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this Exception ex, string message)
        {
            WriteError(ex, message, _eLogErrors, _dbLogErrors, _fLogErrors);
        }

        public static void WriteError(this Exception ex)
        {
            WriteError(ex, _eLogErrors, _dbLogErrors, _fLogErrors);
        }


        public static string GetMessageMethod(string method)
        {
            return String.Format("Ошибка выполнения метода {0}", method);
        }

        public static void WriteErrorMethod(this Exception e, string method, service service, eventID eventID)
        {
            WriteError(e, GetMessageMethod(method), service, eventID);
        }

        public static void WriteErrorMethod(this Exception e, string method, service service)
        {
            WriteError(e, GetMessageMethod(method), service);
        }

        public static void WriteErrorMethod(this Exception e, string method, eventID eventID)
        {
            WriteError(e, GetMessageMethod(method), eventID);
        }

        public static void WriteErrorMethod(this Exception e, string method)
        {
            WriteError(e, GetMessageMethod(method));
        }

        #endregion

        #region Event

        public static long WriteEvents(this string events, string status, service service, eventID eventID)
        {
            Console.WriteLine(String.Format("\nservice: {0}\neventID: {1}\nevents: {2}\nstatus: {3}", service, eventID, events, status));
            WriteWarning(events+", status:"+status, service, eventID);
            return MDBLogs.SaveEvents(events, status, service, eventID);
        }

        public static long WriteEvents(this string events, string status, service service)
        {
            return WriteEvents(events, status, service, eventID.Null);
        }

        public static long WriteEvents(this string events, string status, eventID eventID)
        {
            return WriteEvents(events, status, service.Null, eventID);
        }

        public static long WriteEvents(this string events, string status)
        {
            return WriteEvents(events, status, service.Null, eventID.Null);
        }

        public static long WriteEvents(this string events, EventStatus status, service service, eventID eventID)
        {
            Console.WriteLine(String.Format("\nservice: {0}\neventID: {1}\nevents: {2}\nstatus: {3}", service, eventID, events, status.ToString()));
            WriteWarning(events+", status: "+status.ToString(), service, eventID);
            return MDBLogs.SaveEvents(events, status, service, eventID);
        }

        public static long WriteEvents(this string events, EventStatus status, service service)
        {
            return WriteEvents(events, status, service, eventID.Null);
        }

        public static long WriteEvents(this string events, EventStatus status, eventID eventID)
        {
            return WriteEvents(events, status, service.Null, eventID);
        }

        public static long WriteEvents(this string events, EventStatus status)
        {
            return WriteEvents(events, status, service.Null, eventID.Null);
        }
        #endregion

        #region Services
        /// <summary>
        /// Записать лог сервиса
        /// </summary>
        /// <param name="id_service"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static long WriteServices(this service service, DateTime start, DateTime stop, int code)
        {
            service.WriteStatusServices(start, stop);
            return MServicesLog.WriteLogServices(service, start, stop, code);
        }
        /// <summary>
        /// Записать статус сервиса после выполнения
        /// </summary>
        /// <param name="id_service"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public static long WriteStatusServices(this service service, DateTime start, DateTime stop)
        {
            return MServicesLog.WriteLogStatusServices(service, start, stop);
        }
        /// <summary>
        /// Записать статус сервиса при запуске
        /// </summary>
        /// <param name="id_service"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static long WriteStatusServices(this service service, DateTime start)
        {
            return MServicesLog.WriteLogStatusServices(service, start);
        }
        #endregion

        /// <summary>
        /// Возращает скорректированую ошибку eventID + error_code
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="error_code"></param>
        /// <returns></returns>
        static public int GetEventIDErrorCode(this eventID ev, int error_code)
        {
            return ((int)ev * (-10)) + error_code;
        }
    }
}
