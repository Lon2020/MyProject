/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

/**
 *
 * @author sorak
 */
public class Password {
    private String password;
    boolean access;

    public Password(String password, boolean access) {
        this.password = password;
        this.access = access;
    }

    public boolean isAccess() {
        return access;
    }
    public Password(String password) {
        this.password = password;
    }

    public String getPassword() {
        return password;
    }
    
}
