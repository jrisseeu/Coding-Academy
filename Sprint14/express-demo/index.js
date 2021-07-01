const Joi = require('joi');
const express = require('express');
const app = express();
app.use(express.json());

const courses = [
{id: 1, name: 'course 1'},
{id: 2, name: 'course 2'},
{id: 3, name: 'course 3'},

];

//Get Route
app.get('/', (req,res) => {
    res.send('Hello Wold!!'); //route handler
});

app.get('/api/courses', (req,res) => {
    res.send(courses);
});


//get by ID
app.get('/api/courses/:id', (req,res) => {
   const course = courses.find(c => c.id === parseInt(req.params.id));
   if (!course) res.status(404).send('The course with the proved ID was not found');
   res.send(course);
});

//Insert
app.post('/api/courses', (req,res) => {
    //validate course
    //if invalid, return 400
    const { error } = validateCourse(req.body);
    if (error) return res.status(400).send(error.details[0].message);
        
    const course = {
        id: courses.length + 1,
        name: req.body.name
    }
    courses.push(course);
    res.send(course);
});

//Update
app.put('/api/courses/:id', (req,res) => {
    //look up course
     //if not exists, return 404
    const course = courses.find(c => c.id === parseInt(req.params.id)); 
    if (!course) return res.status(404).send('The course with the proved ID was not found');
     
    // validate course
    //if invalid, return 400
    const { error } = validateCourse(req.body);
    if (error) return res.status(400).send(error.details[0].message);

    //Update course
    course.name =  req.body.name;
    //return updated course to client
    res.send(course);
});

//delete
app.delete('/api/courses/:id', (req,res) => {

    //look up course
     //if not exists, return 404
     const course = courses.find(c => c.id === parseInt(req.params.id)); 
     if (!course) return res.status(404).send('The course with the proved ID was not found');

     //Delete
    const index = courses.indexOf(course);
    courses.splice(index,1);

    //Return
    res.send(course);

})



function validateCourse(course) {
    const schema = {
        name: Joi.string().min(3).required()
    };

    return Joi.validate(course, schema);

}







//app.listen(3000, ()=> console.log('Listening on port 3000...'));
//set PORT=5000 in cmd  <-- does not work.... 
//PORT environment variable
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}... `));