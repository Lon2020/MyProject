/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import DAO.MongoDBManager;
import Model.Employee;
import Model.MonthlyAttendance;
import java.io.IOException;
import java.util.ArrayList;
import javax.servlet.annotation.WebServlet;
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
@WebServlet(name = "C103_SaveToDatabase", urlPatterns = {"/C103_SaveToDatabase"})
public class C103_SaveToDatabase extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        HttpSession session = request.getSession();
        MongoDBManager db = (MongoDBManager) session.getAttribute("Query");
        ArrayList<MonthlyAttendance> monthlyAttendanceList = (ArrayList<MonthlyAttendance>) session.getAttribute("monthlyAttendanceList");
        ArrayList<Employee> employeeList = (ArrayList<Employee>) session.getAttribute("employeeList");
        ArrayList<String> employeeListNew = (ArrayList<String>) session.getAttribute("newEmployeeList");
        ArrayList<String> empNameList = new ArrayList<String>();

        int monthlyOff = 0;
        if (!("" + (String) request.getParameter("monthlyOff")).equals("")) {
            monthlyOff = Integer.parseInt("" + (String) request.getParameter("monthlyOff"));
        }
        System.out.println(monthlyOff);

        for (int i = 0; i < employeeList.size(); i++) {
            empNameList.add(employeeList.get(i).getName());
        }
        for (int i = 0; i < employeeList.size(); i++) {
            int swapNum = 0;
            int sickNum = 0;
            if (!("" + (String) request.getParameter(employeeList.get(i).getName() + "swapNum")).equals("")) {
                swapNum = Integer.parseInt("" + (String) request.getParameter(employeeList.get(i).getName() + "swapNum"));
            }
            if (!("" + (String) request.getParameter(employeeList.get(i).getName() + "sick")).equals("")) {
                sickNum = Integer.parseInt("" + (String) request.getParameter(employeeList.get(i).getName() + "sick"));
            }
            employeeList.get(i).setNormalWage((String) request.getParameter(employeeList.get(i).getName() + "normalWage"));
            employeeList.get(i).setBonusWage((String) request.getParameter(employeeList.get(i).getName() + "bonusWage"));
            if (employeeListNew.contains(employeeList.get(i).getName())) {
                db.CreateEmployee(employeeList.get(i));
            } else {
                db.UpdateEmployee(employeeList.get(i));
            }

            String[] swapNameList = new String[swapNum];
            int count = 0;
            while (swapNum != count) {
                swapNameList[count] = ((String) request.getParameter(employeeList.get(i).getName() + "employeeSelect" + count));
                MonthlyAttendance Emp2Attendance = monthlyAttendanceList.get(empNameList.indexOf(swapNameList[count]));
                Emp2Attendance.setOvertime(Emp2Attendance.getOvertime() - (7 * 60));
                Emp2Attendance.setOvertimeCount(Emp2Attendance.getOvertimeCount() - 1);
                count++;
            }
            monthlyAttendanceList.get(i).setSickNum(sickNum);
            monthlyAttendanceList.get(i).setSwapNum(swapNum);
            monthlyAttendanceList.get(i).setSwapNumList(swapNameList);
            monthlyAttendanceList.get(i).setMonthlyOff(monthlyOff);
        }
        db.CreateMonthyAttendance(monthlyAttendanceList);
    }
}
