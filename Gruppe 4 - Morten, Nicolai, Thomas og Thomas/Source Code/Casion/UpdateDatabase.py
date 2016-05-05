import sqlite3 as lite
import sys
from System import Console

con = None

Console.WriteLine("Saving...")

def Update(id, money):
    try:
        con = lite.connect('Users.db')
        cur = con.cursor()
    
        with con:
            cur.execute("UPDATE Player SET Money = " + money + " WHERE Id = " + id)

    except lite.Error, e:
        print "Error %s:" % e.args[0]
        sys.exit(1)
    
    finally:
        if con:
            con.close()