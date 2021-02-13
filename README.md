# Vivino-app-appium
<h3> Test View Wine page </h3>

<h3> Prerequisite </h3>

1. "Vivino" app for Android, version 8.18.11, which can be downloaded as APK package from [apkmirror-vivino-app](https://www.apkmirror.com/apk/vivino/vivino-wine-scanner/vivino-wine-scanner-8-18-11-release/vivino-buy-the-right-wine-8-18-11-3-android-apk-download/download)

<h3> Test Step </h3>

1.	Run the Vivino app in the Android emulator.
2.	Register in Vivino to create your own <b>email + password</b>, which you will use for the app testing. This registration is done by hand (not by the unit tests), one time only.
3.	Login with pre-registered <b>email + password</b>.
4.	Click on the [Search] tab
5.	Enter the following keywords for searching: <b>"Katarzyna Reserve Red 2006"</b>.
6.	Click on the first search result.
7.	Assert that the wine name is correct: <b>"Reserve Red 2006"</b>.
8.	Assert the wine rating is a number in the range `[1.00 ... 5.00]`.
9.	Assert the wine highlights contain <b>"Among top 1% of all wines in the world"</b>.
10.	Assert the wine facts hold <b>"Grapes: Cabernet Sauvignon,Merlot"</b>.

