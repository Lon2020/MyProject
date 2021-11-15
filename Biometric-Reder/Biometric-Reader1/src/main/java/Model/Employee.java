/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

/**
 *
 * @author Piseth
 */
public class Employee {

    private String name;
    private String department;
    private String normalWage = "";
    private String bonusWage = "";
    private String date = "";

    public String getDate() {
        return date;
    }

    public Employee(String name, String department, String normalWage, String bonusWage, String date) {
        this.name = name;
        this.department = department;
        this.normalWage = normalWage;
        this.bonusWage = bonusWage;
        this.date = date;

    }

    public Employee(String name, String department) {
        this.name = name;
        this.department = department;
    }

    public String getName() {
        return name;
    }

    public String getDepartment() {
        return department;
    }

    public String getNormalWage() {
        return normalWage;
    }

    public String getBonusWage() {
        return bonusWage;
    }

    public void setNormalWage(String normalWage) {
        this.normalWage = normalWage;
    }

    public void setBonusWage(String bonusWage) {
        this.bonusWage = bonusWage;
    }

}
