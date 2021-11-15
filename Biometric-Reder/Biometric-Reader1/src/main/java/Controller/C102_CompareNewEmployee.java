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
import java.util.ArrayList;
import java.util.HashSet;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Piseth
 */
@WebServlet(name = "C102_CompareNewEmployee", urlPatterns = {"/C102_CompareNewEmployee"})
public class C102_CompareNewEmployee extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        HttpSession session = request.getSession();
        MongoDBManager db = (MongoDBManager) session.getAttribute("Query");

        if (db == null) {
            db = new MongoDBManager();
            session.setAttribute("Query", db);
        }
        ArrayList<Employee> employeeListDB = db.GetEmployee();
        ArrayList<Employee> employeeListsession = (ArrayList<Employee>) session.getAttribute("employeeList");
        ArrayList<String> employeeList = new ArrayList<String>();
        for (int i = 0; i < ((ArrayList<Employee>) session.getAttribute("employeeList")).size(); i++) {
            employeeList.add(((ArrayList<Employee>) session.getAttribute("employeeList")).get(i).getName());
        }
        for (int i = 0; i < employeeListDB.size(); i++) {
            if (employeeList.contains(employeeListDB.get(i).getName())) {
                int index = employeeList.indexOf(employeeListDB.get(i).getName());
                employeeListsession.remove(index);
                employeeList.remove(index);
                employeeListsession.add(employeeListDB.get(i));
            }
        }
        session.removeAttribute("employeeList");
        session.setAttribute("employeeList", employeeListsession);
        session.setAttribute("newEmployeeList", employeeList);
        response.sendRedirect("/Biometric-Reader/Upload/EmployeeDetails.jsp");
    }
}
