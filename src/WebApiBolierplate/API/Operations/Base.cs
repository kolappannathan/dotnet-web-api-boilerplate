using Core.Lib;
using Core.Lib.Adapters;
using Core.Constants;

namespace API.Operations;

public class Base
{
    #region [Declarations]

    public DBAdapter dBAdapter;
    public Core.Lib.Helpers helper;
    public CsvLogger csvLogger;

    #endregion [Declarations]

    public Base(IConfiguration configuration)
    {
        csvLogger = new CsvLogger();
        helper = new Core.Lib.Helpers();

        // uncomment this line when there is a valid connection string

        //dBAdapter = new DBAdapter(configuration["AppConfig:DataBase:ConnectionString"]);
    }
}
