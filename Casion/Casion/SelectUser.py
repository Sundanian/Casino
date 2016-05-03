import sqlite3 as lite
import sys

con = None

con = lite.connect('Users.db')
    
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

playerinput = raw_input("Select a save file (Write the ID number)\n")
  
with con: 
    cur.execute("Select * from Player where Id = " + playerinput)
playersave = cur.fetchall()
for row in playersave:
    playerId = row[0]
    playerName = row[1]
    playerMoney = row[2]