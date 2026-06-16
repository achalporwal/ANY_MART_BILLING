package db;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;
public class DatabaseConfig{
  private static String dbUrl = "jdbc:postgresql://localhost:5432/anymart";
  private static String dbUser = "postgres";
  private static String dbPassword = "password";
  
}
