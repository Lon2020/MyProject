package DAO;
import com.mongodb.MongoClient;
import com.mongodb.MongoClientURI;
import com.mongodb.client.*;



public class MongoDBConnector extends MongoDB{
    
    private MongoClient client;
    private MongoDatabase dbs;
    
    public MongoDBConnector() {

    }
    public MongoDatabase DBConnect() {
        
        MongoClientURI uri = new MongoClientURI("mongodb://"+dbuser+":"+dbpass+"@cluster1-shard-00-00.ewgkz.mongodb.net:27017,cluster1-shard-00-01.ewgkz.mongodb.net:27017,cluster1-shard-00-02.ewgkz.mongodb.net:27017/"+db+"?ssl=true&replicaSet=atlas-wb7jrq-shard-0&authSource=admin&retryWrites=true&w=majority");
        client = new MongoClient(uri);
        dbs = client.getDatabase(db);
        return dbs;
    
    }
}
