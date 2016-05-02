import sqlite3 as lite
import sys

con = None

con = lite.connect('test.db')
    
cur = con.cursor()    

playerId = 0
playerName = ""
playerMoney = 0
    
cur.execute("Select * from Player")
rows=cur.fetchall()
for row in rows:
    print "Save ID", row[0]
    print "Save Name", row[1]
    print "Save Money", row[2]

def SelectPlayer(playerinput):    
    cur.execute("Select * from Player where Id = " + playerinput)
    playersave = cur.fetchall()
    for row in playersave:
        global playerId
        playerId = row[0]
        global playerName
        playerName = row[1]
        global playerMoney
        playerMoney = row[2]