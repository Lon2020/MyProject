/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import Model.Shift;

/**
 *
 * @author Piseth & O'Neil
 */
public class DailyAttendance {

    private String clockIn;
    private String clockOut;

    // Time converted into minutes
    private int clockInMinutes;
    private int clockOutMinutes;

    // Tolerance of what the Client finds acceptable before the Employee is "Late" 
    private final int tolerance = 60; // 1 hour tolerance

    private int normalWork = 0; // the minutes the Employee works within the scheduled time
    private int overtime = 0; // the minutes the Employee is working overtime
    private int late = 0; // the minutes the Employee is late

    Shift morningShift = new Shift("Morning Shift", "09:00", "16:00");
    Shift nightShift = new Shift("Night Shift", "16:00", "23:00");

    public DailyAttendance(String data) {

        if (data.equals("Not coming today")) {
            data = "";
        }
        if (data.trim().length() == 0) { 
            // No values in cell will return empty strings for clock-in & out with no attendance and add alpha counter
            this.clockIn = "";
            this.clockOut = "";
        } else { 
            // If there are values in the cell, then do the rest of the calculation
            
            /* Retrieve clock times from cell */
            this.clockIn = data.substring(0, 5); // Retrieves the first 5 characters
            this.clockOut = data.substring(data.length() - 5); // Retrieves the last 5 characters

            normalWork += TimeToMinuteConverter("07:00"); // 7 hours of work

            /* Converts time to minutes */
            clockInMinutes = TimeToMinuteConverter(this.clockIn);
            clockOutMinutes = TimeToMinuteConverter(this.clockOut);
            
            if (clockOutMinutes <= (clockInMinutes + tolerance)) {
                // Forgot: If employee forgets to either clock-in or clock-out, within the tolerance threshold, then return half shift
                normalWork -= (TimeToMinuteConverter("07:00") / 2); // 3.5 hours of work
            } else if (clockInMinutes <= TimeToMinuteConverter("14:00")) {
                Calculation(morningShift);
            } else {
                Calculation(nightShift);
            }
        }
    }
    

    /**
     *  Calculation for Working Hours, if Early, Normal, Overtime, Late or Forgot
     * 
     *  @param  s   the input 
     */
    private void Calculation(Shift s) {
        if (clockInMinutes < s.getStartMinute()){
            overtime += (s.getStartMinute() - clockInMinutes);
        } else if (clockInMinutes > s.getStartMinute() + tolerance) {
            late += (clockInMinutes - s.getStartMinute());
        }
        
        if (clockOutMinutes > s.getEndMinute()){
            overtime += (clockOutMinutes - s.getEndMinute());
        } else if (clockOutMinutes < s.getEndMinute() - tolerance) {
            late += (s.getEndMinute() - clockOutMinutes);
        }
    }

    /**
     * Converts Clock-in or Clock-out times to Minutes
     *
     * @param   clock   the time of Clock-in or Clock-out
     * @return  int     the converted time in minutes
     */
    private int TimeToMinuteConverter(String clock) {
        return (Integer.parseInt(clock.substring(0, 2)) * 60) + (Integer.parseInt(clock.substring(3)));
    }

    // Returns boolean if the Employee has or has not attended
    public boolean isAttend() {
        return this.clockIn.length() != 0;
    }

    public String getclockIn() {
        return clockIn;
    }

    public String getclockOut() {
        return clockOut;
    }

    public int getOvertime() {
        return overtime;
    }

    public int getLate() {
        return late;
    }

    public int getNormalWork() {
        return normalWork;
    }
    
}
