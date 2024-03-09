# This sample code uses the Appium python client v2
# pip install Appium-Python-Client
# Then you can paste this into a file and simply run with Python

from appium import webdriver
from appium.webdriver.common.appiumby import AppiumBy

# For W3C actions
from selenium.webdriver.common.action_chains import ActionChains
from selenium.webdriver.common.actions import interaction
from selenium.webdriver.common.actions.action_builder import ActionBuilder
from selenium.webdriver.common.actions.pointer_input import PointerInput
from appium.options.android import UiAutomator2Options

import time

caps = {}
caps["platformName"] = "Android"
caps["appium:platformVersion"] = "12"
caps["appium:deviceName"] = "Pixel 5 API 31"
caps["appium:automationName"] = "UiAutomator2"
caps["appium:app"] = "C:\\Users\\HAI DANG\\Downloads\\Budget Buddy (Budget Planner)_3.7.0_Apkpure.apk"
caps["appium:avd"] = "Pixel_5_API_31"
caps["appium:ensureWebviewsHavePages"] = True
caps["appium:nativeWebScreenshot"] = True
caps["appium:newCommandTimeout"] = 3600
caps["appium:connectHardwareKeyboard"] = True

capabilities_options = UiAutomator2Options().load_capabilities(caps)
driver = webdriver.Remote("http://127.0.0.1:4723/wd/hub", caps, options=capabilities_options)

def test01() : # test khi chưa có budget
    try :
        el1 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Let's Start")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()
        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()
        if(driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="No budget for this month")) :
            print("test01 Success")   
        else :
            print("test01 fail")
    # actions = ActionChains(driver)
    # actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
    # actions.w3c_actions.pointer_action.move_to_location(542, 2013)
    # actions.w3c_actions.pointer_action.pointer_down()
    # actions.w3c_actions.pointer_action.pause(0.1)
    # actions.w3c_actions.pointer_action.release()
    # actions.perform()
        
    # el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.view.View[@text=\"Sun, 19 Nov 2023\"]")
    # el1.click()
    # el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="17, Friday, November 17, 2023")
    # el2.click()
    # el3 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="OK")
    # el3.click()
    # el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
    # el4.click()
    # el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
    # el5.click()
    # el6 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
    # el6.click()
    # el6.send_keys("25000")
    # el7 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
    # el7.send_keys("Eating")
    except Exception as e:
        print(e)
        print("test01 fail")

def addBudget (budget_name, price) :
    driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Budget").click()

    actions = ActionChains(driver)
    actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
    actions.w3c_actions.pointer_action.move_to_location(538, 2022)
    actions.w3c_actions.pointer_action.pointer_down()
    actions.w3c_actions.pointer_action.pause(0.1)
    actions.w3c_actions.pointer_action.release()
    actions.perform()
    

    el2 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
    el2.click()
    el2.send_keys(budget_name)
    el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
    el3.click()
    el3.send_keys(price)
    el4 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
    el4.click()
    print("add budget success")

def test02() : # test nếu bỏ trống loại budget
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("150000")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        if (driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Please select budget")) :
            print("test02 Success")
        else :
            print("test02 fail")
        driver.back()
    except Exception as e:
        print(e)
        print("test02 fail")

def test03() : # test nếu bỏ trống số tiền
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
        el2.click()

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        if (driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Please input amount")) :
            print("test03 Success")
        else :
            print("test03 fail")
        driver.back()
    except Exception as e:
        print(e)
        print("test03 fail")

def test04() : # test nếu số tiền chứa ký tự không phải số
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
        el2.click()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("28abc")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        print("test04 Success")
        driver.back()
    except Exception as e:
        print(e)
        print("test04 fail")
        driver.back()

def test05() : # test nếu thông tin hợp lệ
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
        el2.click()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("280000")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        if (driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SUN, 19-NOV-2023\n280,000\nABC\nABCD\n280,000")) :
            print("test05 Success")
        else :
            print("test05 fail")
    except Exception as e:
        print(e)
        print("test05 fail")
        driver.back()
def test06() : # test nếu thông tin hợp lệ và số tiền chi vượt quá budget
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
        el2.click()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("3000000")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        el8 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Cancel")
        el8.click()
        driver.back()        
        driver.back()

        # sleep driver
        time.sleep(5)

        if (driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SUN, 19-NOV-2023\n280,000\nABC\nABCD\n280,000")) :
            print("test06 Success")
        else :
            print("test06 fail")
    except Exception as e:
        print(e)
        print("test06 fail")
        driver.back()

def test07() : # test số tiền quá budget
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
        el2.click()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("3000000")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        
        el8 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Yes")
        el8.click()

        print("test07 Success")

    except Exception as e:
        print(e)
        print("test07 fail")
        driver.back()

def test08() : # test nếu số tiền là số âm
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
        el2.click()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("-1")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        if (driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Invalid amount")) :
            print("test08 Success")
        else :
            print("test08 fail")
        driver.back()
    except Exception as e:
        print(e)
        print("test08 fail")
        driver.back()

def test09() : # test nếu số tiền là số 0
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABC")
        el2.click()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("0")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        if (driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Invalid amount")) :
            print("test09 Success")
        else :
            print("test09 fail")
        driver.back()
    except Exception as e:
        print(e)
        print("test09 fail")
        driver.back()

def test10() : # test nếu thông tin hợp lệ
    try :
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="Expense")
        el2.click()

        actions = ActionChains(driver)
        actions.w3c_actions = ActionBuilder(driver, mouse=PointerInput(interaction.POINTER_TOUCH, "touch"))
        actions.w3c_actions.pointer_action.move_to_location(538, 2026)
        actions.w3c_actions.pointer_action.pointer_down()
        actions.w3c_actions.pointer_action.pause(0.1)
        actions.w3c_actions.pointer_action.release()
        actions.perform()

        el1 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.view.View[5]")
        el1.click()
        el2 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="ABCDE")
        el2.click()

        el3 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[1]")
        el3.click()
        el3.send_keys("3000000")

        el4 = driver.find_element(by=AppiumBy.XPATH, value="//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.view.View/android.widget.EditText[2]")
        el4.click()
        el4.send_keys("ABCD")

        # back button
        driver.back()

        el5 = driver.find_element(by=AppiumBy.ACCESSIBILITY_ID, value="SAVE")
        el5.click()

        driver.back()        

        # sleep driver
        time.sleep(5)

        print("test10 Success")

    except Exception as e:
        print(e)
        print("test10 fail")
        driver.back()

if __name__ == "__main__" :
    test01()
    addBudget("ABC", "2800000")
    test02()
    test03()
    test04()
    test05()
    test06()
    test07()
    test08()
    test09()
    addBudget("ABCDE", "3100000")
    test10()
