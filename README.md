# Graduation-topic
畢業專題

### touch_doble_pot
－－－－－－－日期－－－－－－－

20170729 程式初步檢定，邏輯OK，規劃新方式執行

－－－－－－－－－－－－－－

攝影機 縮放+手勢位移

未完
***

### linerander
用linerander + mesh 碰撞 製作牆壁

－－－－－－－資料－－－－－－－

因塔的連線只有2軸(XZ軸)
Mesh碰撞是在中心底縮放
所以點座標是
0.5 * X ， 0.5 *Z
長度(縮放)為 (X^2 +Z^2)^0.5
用極座標系統換算角度

－－－－－－－－－－－－－－未完
***

### AI_look 
AI視野 

－－－－－－－日期－－－－－－－

20170715 第一版設定

20170719 ~ 20 仿製腳本，腳本失誤，理論確定OK

20170720 腳本完成，修正失誤，加上輔助線，簡易測試暫未找到bug

－－－－－－－資料－－－－－－－

先利用 OverlapCapsule (新增一個球型碰撞偵測) ， 取得範圍內碰撞體再透過 範圍以及障礙判定 為看見

## －－－－－－－－－－－－－－_**20170720暫完**_
***
