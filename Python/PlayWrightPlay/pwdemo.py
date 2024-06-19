from playwright.sync_api import Playwright, sync_playwright, expect

def run(playwright : Playwright) -> None :
    def mouse_operate():
        page.mouse.move(350, 200)
        page.mouse.down()
        page.mouse.move(350, 300)
        page.mouse.move(450, 200)
        page.mouse.move(350, 200)
        page.mouse.up()

        # 浏览器页面使用键鼠
        # page.keyboard.down("Control")


    browser = playwright.chromium.launch(headless=False)
    context = browser.new_context()
    page = context.new_page()

    page.goto("https://draw.yunser.com/")
    page.wait_for_timeout(1000)
    mouse_operate()
    page.wait_for_timeout(1000)
    context.close()
    browser.close()


with sync_playwright() as playwright :
    run(playwright)

