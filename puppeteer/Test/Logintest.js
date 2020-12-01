const puppeteer = require('puppeteer');

(async () => {
  const browser = await puppeteer.launch({headless: false, slowMo: 60 });
  const page = await browser.newPage();
  try {
      
 
  await page.goto('file:///E:/InteranshipWork/InternShip/Login.html');
  await page.type('#email','Hamza@gmail.com');
  await page.type('#password','Hamza12@');
  await Promise.all([
    page.waitForNavigation(), // The promise resolves after navigation has finished
    page.click('#login'), // Clicking the link will indirectly cause a navigation
  ]);
  

  await page.type('#sname','Hamza Aslam');
  await page.type('#email','Hamza@gmail.com');
  await page.type('#phone','03316531746');
  await page.select('#myselect','1','2','3');
  await page.type('#date','11041995');
  await page.type('#password','Hamza12@');
  await page.type('#confirmpassword','Hamza12@');
  
 const [filechooser] = await Promise.all([
    page.waitForFileChooser(), 
    page.click('#chose'), 
  ]);
  await filechooser.accept(['C:/Users/hp/Desktop/images.jpeg']);
  await delay(2000);


 // await page.type('#image','Hamza12@');
  await Promise.all([
    page.waitForNavigation(), // The promise resolves after navigation has finished
    page.click('#btn'), // Clicking the link will indirectly cause a navigation
  ]);
  await Promise.all([
    page.waitForNavigation(), // The promise resolves after navigation has finished
    page.click('#list'), // Clicking the link will indirectly cause a navigation
  ]);

  await delay(1000);
  await page.click('.editBtn');
  await delay(1000);
  await page.evaluate( () => document.getElementById("esname").value = "");
  await page.type('#esname','Hamza Aslam update');
  await page.evaluate( () => document.getElementById("eemail").value = "");
  await page.type('#eemail','Hamza@gmail.com');
  await page.evaluate( () => document.getElementById("ephone").value = "");
  await page.type('#ephone','03316531746');
  await page.evaluate( () => document.getElementById("myselect").value = "");
  await page.select('#myselect','1','2');
  await page.evaluate( () => document.getElementById("edate").value = "");
  await page.type('#edate','11041995');
  await page.evaluate( () => document.getElementById("epassword").value = "");
  await page.type('#epassword','Hamza12@');
  await page.evaluate( () => document.getElementById("econfirmpassword").value = "");
  await page.type('#econfirmpassword','Hamza12@');
 // await page.evaluate( () => document.getElementById("eemail").value = "");
 await delay(1000);
  page.click('#ebtn');
  await delay(1000);
  await Promise.all([
    page.waitForNavigation(), // The promise resolves after navigation has finished
    page.click('#list'), // Clicking the link will indirectly cause a navigation
  ]);
  await delay(1000);
  page.click('#deleteBtn');
  await delay(1000);
  await page.screenshot({path: 'login.png'});
 
  await browser.close();
} catch (error) {
      console.log(error);
}
})();
function delay(time) {
    return new Promise(function(resolve) { 
        setTimeout(resolve, time)
    });
  } 