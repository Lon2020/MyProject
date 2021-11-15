/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAO;

import Model.Employee;
import Model.Hash;
import Model.MonthlyAttendance;
import Model.Password;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Locale;
import jxl.write.DateTime;
import org.bson.Document;

/**
 *
 * @author sorak
 */
public class MongoDBManager {

    MongoDBConnector Mongo = new MongoDBConnector();
    private final MongoDatabase db = Mongo.DBConnect();
    private ArrayList<Document> DatabaseList = new ArrayList();

    MongoCollection<Document> Employee = db.getCollection("Employee");
    MongoCollection<Document> Attendance = db.getCollection("Attendance");
    MongoCollection<Document> PasswordHash = db.getCollection("PasswordHash");
    Document WhereDocs;
    Hash Hash = new Hash();

    public void test(String name) {
        WhereDocs = new Document()
                .append("Name", name);
        Employee.insertOne(WhereDocs);
    }

    public void CreateEmployee(Employee employee) {
        //For date & time
        String dateNow = null;
        DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("MMMM yyyy");
        LocalDateTime Expire = LocalDateTime.now(ZoneId.of("Asia/Singapore"));
        String date = (dateFormat.format(Expire));
        dateNow = date;
        WhereDocs = new Document()
                .append("employeeName", employee.getName())
                .append("department", employee.getDepartment())
                .append("normalWage", employee.getNormalWage())
                .append("bonusWage", employee.getBonusWage())
                .append("UploadedTime", dateNow);
        Employee.insertOne(WhereDocs);
    }

    public void CreateMonthyAttendance(ArrayList<MonthlyAttendance> monthlyAttendance) {
        for (int i = 0; i < monthlyAttendance.size(); i++) {
            WhereDocs = new Document()
                    .append("employeeName", monthlyAttendance.get(i).getEName())
                    .append("workingMinutes", monthlyAttendance.get(i).getWorkingMin())
                    .append("late", monthlyAttendance.get(i).getLate())
                    .append("lateCount", monthlyAttendance.get(i).getLateCount())
                    .append("overtime", monthlyAttendance.get(i).getOvertime())
                    .append("overtimeCount", monthlyAttendance.get(i).getOvertimeCount())
                    .append("alpha", monthlyAttendance.get(i).getAlpha())
                    .append("halfShiftCount", monthlyAttendance.get(i).getHalfShiftCount())
                    .append("sick", monthlyAttendance.get(i).getSickNum())
                    .append("swap", monthlyAttendance.get(i).getSwapNum())
                    .append("swapNumList", monthlyAttendance.get(i).getSwapNumList())
                    .append("monthlyOff", monthlyAttendance.get(i).getMonthlyOff());
            Attendance.insertOne(WhereDocs);
        }
    }

    public ArrayList<Employee> GetEmployee() {
        WhereDocs = new Document();
        ArrayList<Employee> employeeList = new ArrayList<Employee>();
        for (Document result : Employee.find(WhereDocs)) {
            employeeList.add(new Employee(
                    (String) result.get("employeeName"),
                    (String) result.get("department"),
                    (String) result.get("normalWage"),
                    (String) result.get("bonusWage"),
                    (String) result.get("UploadedTime")));
        }
        return employeeList;
    }

    /*
    public void CreatePassword(String Password)
    {
        String finalPassword = Hash.getHash(Password);
        Password passWord = new Password(finalPassword);

        WhereDocs = new Document()
                .append("password", passWord.getPassword());

        
        PasswordHash.insertOne(WhereDocs);
        

    }*/
    public Password CheckPassword(String Password) {
        Password password;
        WhereDocs = new Document();
        String finalPassword = Hash.getHash(Password);
        String DB_password = "";
        for (Document result : PasswordHash.find(WhereDocs)) {
            DB_password = ((String) result.get("password"));
        }
        boolean access = finalPassword.equals(DB_password);
        if (access) {
            password = new Password(Password, access);
        } else {
            password = new Password("", false);
        }
        return password;
    }
    
    public void UpdateEmployee(Employee employee){
        Document WhereDocs = new Document("employeeName", employee.getName());
        Document ToDocs = new Document()
                .append("normalWage", employee.getNormalWage())
                .append("bonusWage", employee.getBonusWage());
        Employee.updateOne(WhereDocs, new Document("$set", ToDocs));
    }
}
