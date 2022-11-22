using DataLayer;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var connectionString = "host=cit.ruc.dk;db=cit05;uid=cit05;pwd=nR0RFohmp9iY";

UseAdo(connectionString);
UseAdoStoredProcedure(connectionString);
UseAdoViaEntityFramework(connectionString);
UseEntityFramework(connectionString);
UseEntityFrameworkToCallFunction(connectionString);
CallScalarAdoViaEntityFramework(connectionString);
CallScalarWitExtensionMethod(connectionString);


void UseAdo(string connectionString)
{
    Console.WriteLine("Plain ADO");
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();

    using var cmd = new NpgsqlCommand("select * from search('%ab%')", connection);

    using var reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}");
    }
}

void UseAdoStoredProcedure(string connectionString)
{
    Console.WriteLine("Plain ADO stored procedure");
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();

    using var cmd = new NpgsqlCommand("select * from search(@query)", connection);

    cmd.Parameters.AddWithValue("@query", "%ab%");

    using var reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}");
    }
}

void UseAdoViaEntityFramework(string connectionString)
{
    throw new NotImplementedException();
}

void UseEntityFramework(string connectionString)
{
    throw new NotImplementedException();
}

void UseEntityFrameworkToCallFunction(string connectionString)
{
    throw new NotImplementedException();
}

void CallScalarAdoViaEntityFramework(string connectionString)
{
    throw new NotImplementedException();
}

void CallScalarWitExtensionMethod(string connectionString)
{
    throw new NotImplementedException();
}

