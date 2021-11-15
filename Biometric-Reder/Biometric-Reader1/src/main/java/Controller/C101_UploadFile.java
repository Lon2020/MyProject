/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Model.DailyAttendance;
import Model.Employee;
import Model.MonthlyAttendance;
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

//Reading XLS file
import java.io.InputStream;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import javax.servlet.RequestDispatcher;
import org.apache.commons.fileupload.FileItem;
import org.apache.commons.fileupload.FileUploadException;
import org.apache.commons.fileupload.disk.DiskFileItemFactory;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;

/**
 *
 * @author sorak
 */
@WebServlet(name = "C101_UploadFile", urlPatterns = {"/C101_UploadFile"})
public class C101_UploadFile extends HttpServlet {

    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        HttpSession session = request.getSession();
        int MB = 1024 * 1024; // Create MB
        int maxFileSize = 100 * MB; // Max MB
        int maxMemSize = 100 * MB; // Max memory
        boolean name = false;
        boolean department = false;
        String EName = "";
        String EDepartment = "";
        int count = 0;
        boolean countColoum = true;
        boolean attendanceStart = false;
        String Value = "";
        //Model object
        Employee employee;
        MonthlyAttendance monthlyAttendance;
        //ArrayList for monthlyAttendance
        ArrayList<Employee> employeeList = new ArrayList();
        ArrayList<DailyAttendance> monthlyRecord = new ArrayList();
        ArrayList<MonthlyAttendance> monthlyAttendanceList = new ArrayList();

        InputStream xlsContentStream = null;
        if (ServletFileUpload.isMultipartContent(request)) {
            DiskFileItemFactory factory = new DiskFileItemFactory();
            //Set memory size
            factory.setSizeThreshold(((int) maxMemSize));
            ServletFileUpload fileupload = new ServletFileUpload(factory);
            //file size
            fileupload.setSizeMax(maxFileSize);
            //Read file
            try {
                List fileItems = fileupload.parseRequest(request);
                Iterator i = fileItems.iterator();
                while (i.hasNext()) {
                    FileItem fi = (FileItem) i.next();
                    if (!fi.isFormField()) { // Input type Text
                        xlsContentStream = fi.getInputStream(); // Get the file
                        //InputStream ExcelFileToRead = new FileInputStream("item");
                        //Excel file
                        HSSFWorkbook workbook = new HSSFWorkbook(xlsContentStream);
                        //Excel Sheet
                        HSSFSheet sheet = workbook.getSheetAt(2);
                        //Loop all rows
                        Iterator rows = sheet.rowIterator();
                        while (rows.hasNext()) {
                            HSSFRow row = (HSSFRow) rows.next();
                            int attendancecount = 1;
                            boolean empty = true;
                            //For each row, iterate through each columns
                            Iterator cells = row.cellIterator();
                            while (cells.hasNext()) {
                                HSSFCell cell = (HSSFCell) cells.next();

                                if (cell.getCellTypeEnum().toString().equals("BLANK")) {
                                    Value = "Not coming today";
                                } else if (cell.getCellTypeEnum().toString().equals("STRING")) {
                                    Value = cell.getRichStringCellValue().toString();
                                } else if (cell.getCellTypeEnum().toString().equals("NUMERIC")) {
                                    Value = cell.getNumericCellValue() + "";
                                }
                                if (attendanceStart) {
                                    
                                    if (!Value.equals("Not coming today")) {
                                        empty = false;
                                    }
                                    
                                    //Create dailyAttendance and save into monthlyAttendance
                                    monthlyRecord.add(new DailyAttendance(Value));
                                    
                                    if (attendancecount == count) {
                                        attendanceStart = false;
                                        // Save to Object Employee here and monthlyAttendance
                                        //Save employee object to ArrayList
                                        if (!empty) {
                                            employeeList.add(new Employee(EName, EDepartment));
                                            monthlyAttendanceList.add(new MonthlyAttendance(EName, monthlyRecord));
                                        }
                                        monthlyRecord.clear();
                                        break;
                                    }
                                    attendancecount++;
                                } else if (countColoum) {
                                    if (cell.getCellType() == HSSFCell.CELL_TYPE_NUMERIC) {
                                        count++;
                                    } else if (Value.equals("ID:")) {
                                        countColoum = false;
                                    }
                                } else if (cell.getCellType() == HSSFCell.CELL_TYPE_STRING) {

                                    if (Value.equals("Nama:")) {
                                        name = true;
                                    } else if (Value.equals("Dept.:")) {
                                        department = true;
                                    } else if (name) {
                                        EName = Value;
                                        name = false;
                                    } else if (department) {
                                        EDepartment = Value;
                                        department = false;
                                        attendanceStart = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    xlsContentStream = null; //To reduce memory
                    session.setAttribute("employeeList", employeeList);
                    session.setAttribute("monthlyAttendanceList", monthlyAttendanceList);
                    response.sendRedirect("C102_CompareNewEmployee");
                }
            } catch (IOException | FileUploadException errorMsg) {
                System.out.println(errorMsg);
            }
        }
    }
}
