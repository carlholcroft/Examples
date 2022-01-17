## Contact Us Form Examples
Code demo how to build a contact us form using MailKit. Built with ASP.Net Core C# running .Net 6 the lastest version of 2022.

## Installation


1. Using http://www.mimekit.net/ we are using (MailKit not MimeKit) to send email in demo Project MailKitContactUsExample
2. Clone the repo
   ```sh
   git clone https://github.com/carlholcroft/Examples.git
   ```
   
3. Rename file and add your smtp mail server details
   ```
	appSettings.json.backup to appSettings.json
   
   ```
4. Change these setting in appSetting.json once renamed
   ```
    "EmailSettings": {
    "MailServer": "[Change Me - smtp.ServerName.Here]",
    "MailPort": 465, //Port Number
    "SenderName": "[Change Me - Email From]",
    "Sender": "[Change Me - Sender Email]",
    "Password": "[Change Me - Password ]"
 
    ```

5. Used on windows hosting [https://www.webwiz.co.uk/](https://www.webwiz.co.uk/)

## Licence
Distributed under the MIT License. See LICENSE.txt for more information

Copyright (C) 2022 Carl Holcroft