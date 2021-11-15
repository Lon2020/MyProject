package DAO;
import com.mongodb.connection.Connection;


public class MongoDB {
        protected String db = "BiometricDatabase";//name of the database   
        protected String dbuser  = "Admin"; 
        protected String dbpass = "admin";
        protected Connection conn; //connection null-instance to be initialized in sub-classes
}
