/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import DAO.MongoDBManager;
import Model.Employee;
import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;
import java.util.ArrayList;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author sorak
 */
@WebServlet(name = "C202_SearchDate", urlPatterns = {"/C202_SearchDate"})
public class C202_SearchDate extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException, IllegalStateException {
        HttpSession session = request.getSession();
        MongoDBManager db = (MongoDBManager) session.getAttribute("Query");
        String date = request.getParameter("calender");
        //Get date of each employee
        ArrayList<Employee> employeeListDB = db.GetEmployee();
        //Cate new arrayList to save the date
        ArrayList<Employee> employeeList = new ArrayList<Employee>();
        ArrayList<String> Date = new ArrayList<String>();

        for (int i = 0; i < employeeListDB.size(); i++) {
            Date.add(employeeListDB.get(i).getDate());
            System.out.println(Date.toString());
            if (Date.contains(date)) {
                employeeList.add(employeeListDB.get(i));
            }
            

        }
        session.setAttribute("employeeList", employeeList);
        response.sendRedirect("/Biometric-Reader/Employee/ListEmployee.jsp");
    }
}
