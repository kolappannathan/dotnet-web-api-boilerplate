﻿namespace API.Operations;

public sealed class ValueLib : Base
{
    private string[] values = { "Jon Snow", "Rob Stark", "Sansa Stark", "Arya Stark", "Bran Stark", "Rickon Stark" };

    public ValueLib(IConfiguration configuration) : base(configuration)
    {
    }

    public string[] GetValueList() => values;

    public string GetValueById(int id) => values.Length <= id ? string.Empty : values[id];

    public int AddValue(string value) => 1;

    public int UpdateValue(string value, int id) => values.Length <= id ? -1 : 1;

    public int DeleteValue(int id) => values.Length <= id ? -1 : 1;

}
