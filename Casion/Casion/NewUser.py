import sqlite3 as lite
import sys

con = None
playerId = 0
playerName = ""
playerMoney = 0

try:
    con = lite.connect('Users.db')
    cur = con.cursor()

    name = raw_input("Please enter your name: ")
    cur.execute("INSERT INTO Player VALUES(NULL, '" + name + "', 500)")

    cur.execute("SELECT * from Player ORDER BY Id DESC LIMIT 1") #Gets the player with the highest Id.  Lets hope its our player ;)
    sqPlayer = cur.fetchall()
    for row in sqPlayer:
        playerId = row[0]
        playerName = row[1]
        playerMoney = row[2] 

except lite.Error, e:
    
    print "Error %s:" % e.args[0]
    sys.exit(1)
    
finally:
    if con:
        con.close()