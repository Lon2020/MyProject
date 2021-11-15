/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import DAO.MongoDBManager;
import Model.Password;
import java.io.IOException;
import java.io.PrintWriter;
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
@WebServlet(name = "C201_ValidatePassword", urlPatterns = {"/C201_ValidatePassword"})
public class C201_ValidatePassword extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        HttpSession session = request.getSession();
        MongoDBManager db = (MongoDBManager) session.getAttribute("Query");

        if (db == null) {
            db = new MongoDBManager();
            session.setAttribute("Query", db);
        }
        String Password = ""+(String) request.getParameter("passwordIn");
        
        /*
        //Create Password and save to Data first for the first time
        if(!Password.equals("")){
            Query.CreatePassword(Password);
        }*/
        

        //Compare the password inside data and from jsp page
        Password Checking = db.CheckPassword(Password);
        boolean PasswordValid = Checking.isAccess();
        if(PasswordValid == true){
            response.sendRedirect("/Biometric-Reader/Employee/SearchMonth.jsp");
        }else{
            session.setAttribute("ErrorMsg", " Password is incorrect");
            response.sendRedirect("/Biometric-Reader/Employee/CheckEmployee.jsp");
        }
        
        // Get the date
    }

}
