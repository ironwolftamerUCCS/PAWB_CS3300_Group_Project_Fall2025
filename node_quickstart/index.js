const { MongoClient } = require('mongodb');

async function runGetStarted() {
  // Replace the uri string with your connection string
  const uri = 'mongodb+srv://trinityfalcon1_db_user:jadespass@pawble.iva6lsj.mongodb.net/?appName=Pawble';
  const client = new MongoClient(uri);

  try {
    const database = client.db('PAWBLE');
    const users = database.collection('users');

    // Queries for a user that has a title value of 'jimbob'
    const query = { title: 'Jimbob' };
    const user = await users.findOne(query);

    console.log(user);
  } finally {
    await client.close();
  }
}
runGetStarted().catch(console.dir);
