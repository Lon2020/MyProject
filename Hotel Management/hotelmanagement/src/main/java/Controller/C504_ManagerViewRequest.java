/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import DAO.MongoDBManager;
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
 * @author leeki
 */
@WebServlet(name = "C504_ManagerViewRequest", urlPatterns = {"/C504_ManagerViewRequest"})
public class C504_ManagerViewRequest extends HttpServlet {

    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        HttpSession session = request.getSession();
        MongoDBManager db = (MongoDBManager) session.getAttribute("Query");
        
        if (db == null) {
            db = new MongoDBManager();
            session.setAttribute("Query", db);
        }
        
        //get the booking list by booking ID
        String bookingID = request.getParameter("viewRequest");
        System.out.println("this is my booking id: "+ bookingID);
        
        session.setAttribute("bookingRequest", db.getBookingRequest(bookingID));
        response.sendRedirect("/hotelmanagement/Manager/ManagerViewRequest.jsp");
        
    }
}
