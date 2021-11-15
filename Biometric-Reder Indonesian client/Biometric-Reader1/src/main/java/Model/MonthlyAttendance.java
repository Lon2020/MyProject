/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.ArrayList;
import java.util.Arrays;

/**
 *
 * @author sorak
 */
public class MonthlyAttendance {

    private String EName;
    private ArrayList<DailyAttendance> monthlyRecord = new ArrayList();

    private int workingMin = 0;
    private int late = 0;
    private int lateCount = 0;
    private int overtime = 0;
    private int overtimeCount = 0;
    private int alpha = 0;
    private int halfShiftCount = 0;
    private int sickNum;
    private int swapNum;
    private String[] swapNumList;
    private int monthlyOff;

    public MonthlyAttendance(String EName, ArrayList<DailyAttendance> monthlyRecord) {
        this.EName = EName;
        this.monthlyRecord = (ArrayList<DailyAttendance>) monthlyRecord.clone();
        for (int i = 0; i < this.monthlyRecord.size(); i++) {
            workingMin += this.monthlyRecord.get(i).getNormalWork();
            late += this.monthlyRecord.get(i).getLate();
            overtime += this.monthlyRecord.get(i).getOvertime();

            if (this.monthlyRecord.get(i).getLate() != 0) {
                lateCount++;
            }
            if (this.monthlyRecord.get(i).getOvertime() != 0) {
                overtimeCount++;
            }
            if (!this.monthlyRecord.get(i).isAttend()) {
                alpha++;
            }
            if (this.monthlyRecord.get(i).getNormalWork() == (60 * 7 / 2)) // half working hours
            {
                halfShiftCount++;
            }
        }

    }

    public String getEName() {
        return EName;
    }

    public void setEName(String EName) {
        this.EName = EName;
    }

    public ArrayList<DailyAttendance> getMonthlyRecord() {
        return this.monthlyRecord;
    }

    public void setMonthlyRecord(ArrayList<DailyAttendance> monthlyRecord) {
        this.monthlyRecord = (ArrayList<DailyAttendance>) monthlyRecord.clone();
    }

    public int getSickNum() {
        return sickNum;
    }

    public void setSickNum(int sickNum) {
        this.sickNum = sickNum;
        this.workingMin += sickNum * (60 * 7); // 7 hours of work
        this.alpha -= sickNum;
    }

    public int getSwapNum() {
        return swapNum;
    }

    // do code
    public void setSwapNum(int swapNum) {
        this.swapNum = swapNum;
        this.workingMin += swapNum * (60 * 7);
        this.alpha -= swapNum;
    }

    public int getWorkingMin() {
        return workingMin;
    }

    public void setWorkingMin(int workingMin) {
        this.workingMin = workingMin;
    }

    public int getLate() {
        return late;
    }

    public void setLate(int late) {
        this.late = late;
    }

    public int getLateCount() {
        return lateCount;
    }

    public void setLateCount(int lateCount) {
        this.lateCount = lateCount;
    }

    public int getOvertime() {
        return overtime;
    }

    public void setOvertime(int overtime) {
        this.overtime = overtime;
    }

    public int getOvertimeCount() {
        return overtimeCount;
    }

    public void setOvertimeCount(int overtimeCount) {
        this.overtimeCount = overtimeCount;
    }

    public int getAlpha() {
        return alpha;
    }

    public void setAlpha(int alpha) {
        this.alpha = alpha;
    }

    public int getHalfShiftCount() {
        return halfShiftCount;
    }

    public void setHalfShiftCount(int halfShiftCount) {
        this.halfShiftCount = halfShiftCount;
    }

    public String getSwapNumList() {
        return Arrays.toString(swapNumList);
    }

    public void setSwapNumList(String[] swapNumList) {
        this.swapNumList = swapNumList;
    }

    public void setMonthlyOff(int monthlyOff) {
        this.monthlyOff = monthlyOff;
        this.workingMin += monthlyOff * (60 * 7); // 7 hours of work
    }

    public int getMonthlyOff() {
        return monthlyOff;
    }
}
