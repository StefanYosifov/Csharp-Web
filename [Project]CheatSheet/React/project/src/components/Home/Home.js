


const HomePage=()=>{
    return(
        <>
         <main>
        <section id="hero">
          <h1>Welcome to our educational website!</h1>
          <p>Here you can save all the </p>
          <a href="#" className="btn">Get Started</a>
        </section>
        <section id="features">
          <h2>Our Features</h2>
          <ul>
            <li><i className="fa fa-check"></i>Expert instructors</li>
            <li><i className="fa fa-check"></i>Flexible learning options</li>
            <li><i className="fa fa-check"></i>Certificates of completion</li>
            <li><i className="fa fa-check"></i>Affordable pricing</li>
          </ul>
        </section>
        <section id="testimonials">
          <h2>What Our Students Say</h2>
          <div className="testimonial">
            <img src="img/student1.jpg" alt="Student 1" />
            <p>"I loved the courses on this website! They were informative, engaging, and helped me advance in my career."</p>
            <p className="name">John Doe</p>
          </div>
          <div className="testimonial">
            <img src="img/student2.jpg" alt="Student 2" />
            <p>"I highly recommend this website to anyone looking to learn new skills. The instructors are knowledgeable and the courses are top-notch."</p>
            <p className="name">Jane Smith</p>
          </div>
        </section>
      </main>
        </>
    )
}

export default HomePage;
