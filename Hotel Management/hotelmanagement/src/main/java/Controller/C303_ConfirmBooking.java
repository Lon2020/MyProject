/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import DAO.MongoDBManager;
import Model.Admin;
import Model.Booking;
import Model.Room;
import Model.User;
import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.mail.BodyPart;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMultipart;
import org.apache.commons.lang3.RandomStringUtils;

/**
 *
 * @author sorak
 */
@WebServlet(name = "C303_ConfirmBooking", urlPatterns = {"/C303_ConfirmBooking"})
public class C303_ConfirmBooking extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            HttpSession session;
            session = request.getSession();
            MongoDBManager db = (MongoDBManager) session.getAttribute("Query");

            if (db == null) {
                db = new MongoDBManager();
                session.setAttribute("Query", db);
            }
            //Date Formatter
            SimpleDateFormat dateFormatter = new SimpleDateFormat("yyyy-MM-dd");

            //Get data from database
            Room bookingRoom = (Room) session.getAttribute("bookingRoom");
            ArrayList<Booking> booking = db.getBooking();
            ArrayList<String> avaiableroomId = new ArrayList<String>();
            ArrayList<String> unavaiablieroomId = new ArrayList<String>();

            //Get Datd from Jsp
            String location = request.getParameter("location");
            String fromDate = request.getParameter("fromDate");
            String toDate = request.getParameter("toDate");
            String totalStay = request.getParameter("nights");
            String totalPrice = request.getParameter("totalPrice");
            String bookingID = RandomStringUtils.randomNumeric(8).toString();

            //Change the format of fromDate and toDate
            Date newFromDate = dateFormatter.parse(fromDate);
            Date newtoDate = dateFormatter.parse(toDate);
            boolean canBook = true;

            //Check fromDate and toDate with the database
            for (int i = 0; i < booking.size(); i++) {
                System.out.println(booking.size());

                Date newStartDate = dateFormatter.parse(booking.get(i).getStartDate());
                Date newEndDate = dateFormatter.parse(booking.get(i).getEndDate());
                if (newFromDate.after(newEndDate) || newtoDate.before(newStartDate)) {
                    avaiableroomId.add(booking.get(i).getRoomId());
                } else {
                    unavaiablieroomId.add(booking.get(i).getRoomId());
                }
            }
            //remove unused avaiableroom id to reduce a memory used
            avaiableroomId.clear();

            //If the location is from Index
            if (location.equals("index")) {
                String bookedfor = request.getParameter("bookedfor");
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    //Check if unavaiable room is equlas to all room id that means the selected date cannot be booked
                    if (unavaiablieroomId.get(i).equals(bookingRoom.getRoomNum())) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                //if canBook then save the booking details in the database
                if (canBook) {
                    bookingReceiptEmail(bookedfor, bookingID, bookingRoom.getRoomNum(), bookingRoom.getRoomPrice(), totalStay.replace("Total stay: ", ""), totalPrice.replace("Total price: $", ""), fromDate, toDate);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Homepage/Room.jsp");
                    db.CreateBooking(bookingID, bookingRoom.getRoomNum(), bookingRoom.getRoomPrice(),
                            totalStay.replace("Total stay: ", ""),
                            totalPrice.replace("Total price: $", ""), fromDate, toDate, bookedfor,
                            0, 0, 0, 0,"", false);
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Homepage/Room.jsp");
                }
                //If the location is from customer index
            } else if (location.equals("customerIndex")) {
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(bookingRoom.getRoomNum())) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    User user = (User) session.getAttribute("user");
                    db.CreateBooking(bookingID, bookingRoom.getRoomNum(), bookingRoom.getRoomPrice(),
                            totalStay.replace("Total stay: ", ""),
                            totalPrice.replace("Total price: $", ""), fromDate, toDate, user.getUsername(),
                            0, 0, 0, 0,"", false);
                    bookingReceiptEmail(user.getUsername(), bookingID, bookingRoom.getRoomNum(), bookingRoom.getRoomPrice(), totalStay.replace("Total stay: ", ""), totalPrice.replace("Total price: $", ""), fromDate, toDate);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement//C401_MyBooking");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Customer/CustomerRoom.jsp");
                }

                //If the location is from staff index
            } else if (location.equals("staffIndex")) {
                String bookedfor = request.getParameter("bookedfor");
                //if (db.isUserExist(bookedfor)) {
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(bookingRoom.getRoomNum())) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    System.out.println("I am here");
                    User user = (User) session.getAttribute("user");
                    System.out.println(user);
                    System.out.println(user.getUsername());
                    db.CreateStaffBooking(bookingID, bookingRoom.getRoomNum(), bookingRoom.getRoomPrice(),
                            totalStay.replace("Total stay: ", ""),
                            totalPrice.replace("Total price: $", ""), fromDate, toDate, user.getUsername(), bookedfor);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Staff/StaffRoom.jsp");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Staff/StaffRoom.jsp");
                }
            } //If the customer does not exist
            /*else {
                    session.setAttribute("userNotExist", "User does not exist in the Database.");
                    response.sendRedirect("/hotelmanagement/Staff/StaffConfirmBooking.jsp");*/ // If the index is manager
            else if (location.equals("managerIndex")) {
                String bookedfor = request.getParameter("bookedfor");
                //if (db.isUserExist(bookedfor)) {
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(bookingRoom.getRoomNum())) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    System.out.println("I am here");
                    User user = (User) session.getAttribute("user");
                    System.out.println(user);
                    System.out.println(user.getUsername());
                    db.CreateStaffBooking(bookingID, bookingRoom.getRoomNum(), bookingRoom.getRoomPrice(),
                            totalStay.replace("Total stay: ", ""),
                            totalPrice.replace("Total price: $", ""), fromDate, toDate, user.getUsername(), bookedfor);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Manager/ManagerRoom.jsp");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Manager/ManagerRoom.jsp");
                }
                /*} //If the customer does not exist
                else {
                    session.setAttribute("userNotExist", "User does not exist in the Database.");
                    response.sendRedirect("/hotelmanagement/Manager/ManagerConfirmBooking.jsp");*/
                //}
            } //If the Index is ADMIN
            else if (location.equals("adminIndex")) {
                String bookedfor = request.getParameter("bookedfor");
                //if (db.isUserExist(bookedfor)) {
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(bookingRoom.getRoomNum())) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    System.out.println("I am here");
                    User user = (User) session.getAttribute("user");
                    System.out.println(user);
                    System.out.println(user.getUsername());
                    db.CreateStaffBooking(bookingID, bookingRoom.getRoomNum(), bookingRoom.getRoomPrice(),
                            totalStay.replace("Total stay: ", ""),
                            totalPrice.replace("Total price: $", ""), fromDate, toDate, user.getUsername(), bookedfor);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Admin/AdminRoomTwo.jsp");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Admin/AdminRoomTwo.jsp");
                }
                /*} //If the customer does not exist
                else {
                    session.setAttribute("userNotExist", "User does not exist in the Database.");
                    response.sendRedirect("/hotelmanagement/Admin/AdminConfirmBooking.jsp");
                }*/
            } //If the index is found
            else if (location.equals(
                    "indexFound")) {
                String bookedfor = request.getParameter("bookedfor");
                String roomId = request.getParameter("roomId");
                String roomPrice = request.getParameter("price");
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(roomId)) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    bookingReceiptEmail(bookedfor, bookingID, roomId, roomPrice, totalStay.replace("Total stay: ", ""), totalPrice.replace("Total price: $", ""), fromDate, toDate);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Homepage/Room.jsp");
                    db.CreateBooking(bookingID, roomId, roomPrice,
                            totalStay.replace("Total Stay:  ", ""),
                            totalPrice.replace("Total Price:  $", ""), fromDate, toDate, bookedfor,
                            0, 0, 0, 0,"", false);
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Homepage/Room.jsp");
                }

                //CUSTOMER
            } else if (location.equals(
                    "customerIndexFound")) {
                User user = (User) session.getAttribute("user");
                String roomId = request.getParameter("roomId");
                String roomPrice = request.getParameter("price");
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(roomId)) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    db.CreateBooking(bookingID, roomId, roomPrice,
                            totalStay.replace("Total Stay:  ", ""),
                            totalPrice.replace("Total Price:  $", ""), fromDate, toDate, user.getUsername(),
                            0, 0, 0, 0,"", false);
                    bookingReceiptEmail(user.getUsername(), bookingID, roomId, roomPrice, totalStay.replace("Total stay: ", ""), totalPrice.replace("Total price: $", ""), fromDate, toDate);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement//C401_MyBooking");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Customer/CustomerRoom.jsp");
                }

                //STAFF
            } else if (location.equals(
                    "staffIndexFound")) {
                User user = (User) session.getAttribute("user");
                String roomId = request.getParameter("roomId");
                String roomPrice = request.getParameter("price");
                String bookedfor = request.getParameter("bookedfor");
                //if (db.isUserExist(bookedfor)) {
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(roomId)) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    db.CreateStaffBooking(bookingID, roomId, roomPrice,
                            totalStay.replace("Total Stay:  ", ""),
                            totalPrice.replace("Total Price:  $", ""), fromDate, toDate, user.getUsername(), bookedfor);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Staff/StaffRoom.jsp");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Staff/StaffRoom.jsp");
                }
                /*} else {
                    session.setAttribute("userNotExist", "User does not exist in the Database.");
                    response.sendRedirect("/hotelmanagement/Staff/StaffIndex.jsp");
                }*/

            } //MANAGER
            else if (location.equals(
                    "managerIndexFound")) {
                User user = (User) session.getAttribute("user");
                String roomId = request.getParameter("roomId");
                String roomPrice = request.getParameter("price");
                String bookedfor = request.getParameter("bookedfor");
                //if (db.isUserExist(bookedfor)) {
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(roomId)) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    db.CreateStaffBooking(bookingID, roomId, roomPrice,
                            totalStay.replace("Total Stay:  ", ""),
                            totalPrice.replace("Total Price:  $", ""), fromDate, toDate, user.getUsername(), bookedfor);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Manager/ManagerRoom.jsp");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Manager/ManagerRoom.jsp");
                }
                /*}
                else {
                    session.setAttribute("userNotExist", "User does not exist in the Database.");
                    response.sendRedirect("/hotelmanagement/Manager/ManagerIndex.jsp");
                }*/
            } //ADMIN
            else if (location.equals(
                    "adminIndexFound")) {
                Admin admin = (Admin) session.getAttribute("user");
                String roomId = request.getParameter("roomId");
                String roomPrice = request.getParameter("price");
                String bookedfor = request.getParameter("bookedfor");
                //if (db.isUserExist(bookedfor)) {
                for (int i = 0; i < unavaiablieroomId.size(); i++) {
                    if (unavaiablieroomId.get(i).equals(roomId)) {
                        canBook = false;
                        break;
                    } else {
                        canBook = true;
                    }
                }
                if (canBook) {
                    System.out.print(admin.getUsername());
                    db.CreateStaffBooking(bookingID, roomId, roomPrice,
                            totalStay.replace("Total Stay:  ", ""),
                            totalPrice.replace("Total Price:  $", ""), fromDate, toDate, admin.getUsername(), bookedfor);
                    session.setAttribute("booked", "booked");
                    response.sendRedirect("/hotelmanagement/Admin/AdminRoomTwo.jsp");
                } else {
                    session.setAttribute("same", "same");
                    response.sendRedirect("/hotelmanagement/Admin/AdminRoomTwo.jsp");
                }
                /*} else {
                    session.setAttribute("userNotExist", "User does not exist in the Database.");
                    response.sendRedirect("/hotelmanagement/Admin/AdminIndex.jsp");
                }*/
            }

        } catch (ParseException ex) {
            Logger.getLogger(C303_ConfirmBooking.class
                    .getName()).log(Level.SEVERE, null, ex);
        }
    }

    public static ArrayList<String> createStaffBookingTest(String bookingID, String roomId, String roomPrice, String totalStay,
            String totalPrice, String fromDate, String toDate, String bookedBy, String bookedFor) {

        ArrayList<String> booking = new ArrayList<>();
        booking.add(bookingID);
        booking.add(roomId);
        booking.add(roomPrice);
        booking.add(totalStay);
        booking.add(totalPrice);
        booking.add(fromDate);
        booking.add(toDate);
        booking.add(bookedBy);
        booking.add(bookedFor);

        return booking;
    }

    public void bookingReceiptEmail(String userEmail, String bookingID, String roomNum, String roomPrice, String totalStay, String totalPrice, String fromDate, String toDate) {
        String HOST = "smtp.gmail.com";
        String PORT = "587";

        String toAddress = userEmail;
        String fromAddress = "hotelmanagementservice0@gmail.com";
        String userName = "hotelmanagementservice0@gmail.com";
        String password = "hotelmanagementis1";

        String text = "<p>Dear " + userEmail + ",</p>";
        text += "<h1 style=text-align:center>ROSCY HOTEL</h1>"
                + "<br><h2>INVOICE</h2>"
                + "<h3>Booking Receipt no: " + bookingID + "</h3>"
                + "<p>Room number: " + roomNum + "</p>"
                + "<p>Start date: " + fromDate + "</p>"
                + "<p>End date: " + toDate + "</p>"
                + "<p>Total Stay: " + totalStay + "</p>"
                + "<p>Room Price: " + roomPrice + "</p>"
                + "<h3>Total Price: " + totalPrice + "</h3>"
                + "<br><p>Thank you for trusting us</p>";

        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", HOST);
        props.put("mail.smtp.port", PORT);

        Session session = Session.getInstance(props,
                new javax.mail.Authenticator() {
            @Override
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(userName, password);
            }
        });

        try {

            // Create a default MimeMessage object.
            Message message = new MimeMessage(session);

            // Set From: header field of the header.
            message.setFrom(new InternetAddress(fromAddress));

            // Set To: header field of the header.
            message.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse(toAddress));

            // Set Subject: header field
            message.setSubject("Booking Receipt");

            // This mail has 2 part, the BODY and the embedded image
            MimeMultipart multipart = new MimeMultipart("related");

            // first part (the html)
            BodyPart messageBodyPart = new MimeBodyPart();
            String htmlText = text;
            messageBodyPart.setContent(htmlText, "text/html");
            // add it
            multipart.addBodyPart(messageBodyPart);

            String filePath = getServletContext().getRealPath("/") + "..\\..\\src\\main\\webapp\\Image\\" + roomNum + ".png";
            // second part (the image)
            MimeBodyPart imagePart = new MimeBodyPart();

            imagePart.attachFile(filePath);

            multipart.addBodyPart(imagePart);

            // put everything together
            message.setContent(multipart);
            // Send message
            Transport.send(message);

        } catch (MessagingException | IOException e) {
            System.out.println(e);
            throw new RuntimeException(e);
        }
    }
}
