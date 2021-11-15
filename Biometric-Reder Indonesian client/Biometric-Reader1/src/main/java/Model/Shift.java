/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

/**
 *
 * @author oneilrangiuira
 */
public class Shift {
    private String shiftType;
    private String startOfShift;
    private String endOfShift;

    public Shift(String shiftType, String startOfShift, String endOfShift) {
        this.shiftType = shiftType;
        this.startOfShift = startOfShift;
        this.endOfShift = endOfShift;
    }
    
    public int getStartMinute() {
        return TimeToMinuteConverter(startOfShift);
    }
    
    public int getEndMinute() {
        return TimeToMinuteConverter(endOfShift);
    }

    public String getShiftType() {
        return shiftType;
    }

    public String getStart() {
        return startOfShift;
    }

    public String getEnd() {
        return endOfShift;
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

}