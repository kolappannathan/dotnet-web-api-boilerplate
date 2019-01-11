﻿using Core.Constants;
using Core.Lib;
using Core.Lib.Adapters;

namespace Business.Lib
{
    public class Base
    {
        #region [Declarations]

        public DBAdapter dBAdapter;
        public Helpers helper;
        public Logger logger;

        #endregion [Declarations]

        public Base()
        {
            helper = new Helpers();

            // uncomment this line when there is a valid connection string

            //dBAdapter = new DBAdapter(Config.DataBase.ConnectionString);

            logger = new Logger(Config.Logger.DateFormat, Config.Logger.FileName);
        }
    }
}
