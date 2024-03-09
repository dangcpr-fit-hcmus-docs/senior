package org.example;


import io.appium.java_client.AppiumBy;
import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.net.URL;
import java.time.Duration;
import java.util.ArrayList;
import java.util.Arrays;


// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    static AppiumDriver driver;

    public static void main(String[] args) {
        try {
//          Dataset: 01: Contact Info    02: Contact Name    03: Contact new Phone   04: Contact Email   05: Contact Group
//          Test scenario

//          Add new contact
            System.out.println("Test Scenario 1");
            Test01(dataSet01(), dataSet03(), dataSet04());
            System.out.println();

//

        }
        catch (Exception exception){
            System.out.println(exception.getCause());
            System.out.println(exception.getMessage());
//            exception.printStackTrace();
        }
    }



    public static  void Test01(String[][] data, ArrayList<String> dataPhone, ArrayList<String> dataEmail) throws Exception {

        DesiredCapabilities cap = new DesiredCapabilities();

        cap.setCapability("deviceName", "emulator-5554");
        cap.setCapability("platformName", "Android");
        cap.setCapability("appPackage", "com.simplemobiletools.contacts.pro");
        cap.setCapability("appActivity", ".activities.MainActivity");
        cap.setCapability("noReset", "true");

        URL url = new URL("http://127.0.0.1:4723/wd/hub");
//        String[][] data = dataSet01();
        for (int i = 0; i < data.length; i++) {

            int j=0;
            driver = new AppiumDriver(url, cap);

            Thread.sleep(500);
            var el1 = driver.findElement(AppiumBy.accessibilityId("Create new contact"));
            el1.click();

            Thread.sleep(1500);
            var el2 = driver.findElement(AppiumBy.id("com.simplemobiletools.contacts.pro:id/contact_first_name"));
            el2.click();
            el2.sendKeys(data[i][j++]);

//            Thread.sleep(500);
            var el3 = driver.findElement(AppiumBy.id("com.simplemobiletools.contacts.pro:id/contact_surname"));
            el3.click();
            el3.sendKeys(data[i][j]);

//            Thread.sleep(500);
            var el4 = driver.findElement(AppiumBy.id("com.simplemobiletools.contacts.pro:id/contact_number"));
            el4.click();
            el4.sendKeys(dataPhone.get(i));

//            Thread.sleep(500);
            var el9 = driver.findElement(AppiumBy.id("com.simplemobiletools.contacts.pro:id/contact_email"));
            el9.click();
            el9.sendKeys(dataEmail.get(i));


//            Thread.sleep(500);
            var el5 = driver.findElement(AppiumBy.accessibilityId("Save"));
            el5.click();

            Thread.sleep(500);
            System.out.println("Tess passed "+String.valueOf(i+1));

            Thread.sleep(1000);
            driver.quit();

        }
    }
    private static String[][] dataSet01(){
        return new String[][]{
                {"Nguyen", "Van B"},      //1
                {"Nguyen", "Van C"},      //2
                {"Nguyen", "Van E"},      //3
                {"Nguyen", "Van F"},      //4
                {"Nguyen", "Van G"},      //5
                {"Nguyen", "Van H"},      //6
                {"Nguyen", "Van I"},      //7
                {"Nguyen", "Van K"},      //8
                {"Nguyen", "Van L"},      //9
                {"Nguyen", "Van M"},      //10
        };
    }
    private static ArrayList<String> dataSet02() {
        ArrayList<String> dataSet = new ArrayList<String>();
        String[][] data = dataSet01();
        for (String[] datum : data) {
            dataSet.add(datum[0] + " " + datum[1]);
        }
        return dataSet;
    }
    private static ArrayList<String> dataSet03(){
        ArrayList<String> dataSet = new ArrayList<String>();
        //add phone number
        dataSet.add("0917791883"); //1
        dataSet.add("0917282271");  //2
        dataSet.add("0981694545");  //3
        dataSet.add("0980464017");  //4
        dataSet.add("0987084174");  //5
        dataSet.add("0924362593");  //6
        dataSet.add("0927209318");  //7
        dataSet.add("0915933115");  //8
        dataSet.add("0968312713");  //9
        dataSet.add("0943405492");  //10

        return dataSet;
    }
    private static ArrayList<String> dataSet04(){
        ArrayList<String> dataSet = new ArrayList<String>();
        ArrayList<String>  data = dataSet02();
        for (String datum : data) {
            String tempName = datum.replace(" ", "");
            dataSet.add(tempName + "@gmail.com");
        }
        return dataSet;
    }

}