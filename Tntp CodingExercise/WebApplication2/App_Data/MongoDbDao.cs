using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

public class MongoDbDao
{
    private MongoClient _mongoClient;
    private MongoServer _mongoServer;
    private MongoDatabase _mongoDatabase;
    private string _useCollectionName;

    public MongoDbDao(string databaseName)
    {
        // MongoDB connect string
        string connectionString =
            ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
        // Generate MongoClient object
        _mongoClient = new MongoClient(connectionString);
        // Get MongoServer object
        _mongoServer = _mongoClient.GetServer();
        // Get MongoDatabase object
        _mongoDatabase = _mongoServer.GetDatabase(databaseName);
    }

    public void UseCollection(string collectionName)
    {
        if (string.IsNullOrEmpty(collectionName))
            throw new Exception("collectionName can't empty or null.");

        _useCollectionName = collectionName;
    }

    private MongoCollection<T> GetCollection<T>()
    {
        return _mongoDatabase.GetCollection<T>(_useCollectionName);
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        var collection = GetCollection<T>();
        return collection.AsQueryable<T>();
    }

    public T GetById<T>(Expression<Func<T, bool>> expression) where T : class
    {
        var query = Query<T>.Where(expression);
        var document = GetCollection<T>().FindOne(query);
        return document;
    }

    public bool Insert<T>(T entity) where T : class
    {
        return GetCollection<T>().Insert(entity).Ok;
    }

    public bool Update<T>(T entity) where T : class
    {
        return GetCollection<T>().Save(entity).Ok;
    }

    public bool Delete<T>(Expression<Func<T, bool>> expression) where T : class
    {
        var query = Query<T>.Where(expression);
        return GetCollection<T>().Remove(query).Ok;
    }
}