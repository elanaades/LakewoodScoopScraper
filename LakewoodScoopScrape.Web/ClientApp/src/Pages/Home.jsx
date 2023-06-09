import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Home = () => {

    const [items, setItems] = useState([]);


    useEffect(() => {
        const getArticles = async () => {
            const { data } = await axios.get(`/api/scoopscraper/scrape`);
            setItems(data);
        }

        getArticles();
    }, []);

    return (
        <div>
            <div style={{ marginTop: '100px' }}>
                {items.map(item => (
                    <div className="container" key={item.id} style={{ marginBottom: '100px' }}>
                        <div className="row">
                            <div className="col-md-5">
                                <img src={item.image} alt={item.title} className="img-fluid" />
                            </div>
                            <div className="col-md-5">
                                <h2><a target="_blank" href={item.url}>{item.title}</a></h2>
                                <div style={{ background: 'black', color: 'white', padding: '5px', borderRadius: '5px', display: 'inline-block'}}>
                                    <p style={{ fontSize: '12px', margin: '0' }}>Number of Comments: {item.comments}</p>
                                </div>
                                <p>{item.blurb}</p>
                            </div>
                        </div>
                    </div>
                ))}
            </div>


        </div>
    );
}

export default Home;