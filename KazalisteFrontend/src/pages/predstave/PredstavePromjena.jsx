
import { Button, Col, Container, Form, FormGroup, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import PredstavaService from "../../services/PredstavaService";
import { useEffect, useState } from "react";


export default function PredstavePromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();
    const [predstava, setPredstava] = useState();

    async function dohvatiPredstavu(){
        const o = await PredstavaService.getBySifra(routeParams.sifra);
        if (o.greska){
            console.log(o.poruka);
            alert('Pogledaj konzolu');
            return;
        }

        setPredstava(o.poruka);
    }
      
    useEffect(()=>{
        dohvatiPredstavu();
    },[]);
    
    
    
    function obradiSubmit(e){  
        e.preventDefault();
        //alert('Dodajem predstavu');

        const podaci = new FormData(e.target);

        const predstava = {

           
            naziv: podaci.get('naziv'),  
            //datum: parseDateTime(podaci.get('datum')),
            datum: podaci.get('datum'),
            cijena: parseInt(podaci.get('cijena'))
            
        };

        console.log(predstava);
        //dodaj(predstava);
        }


    return (

        <Container>
            <Form onSubmit={obradiSubmit}>
            
                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="naziv" 
                    defaultValue={predstava.naziv} 
                    required />
                </Form.Group>

                <Form.Group controlId="naziv">
                    <Form.Label>Datum i vrijeme</Form.Label>
                    <Form.Control type="text" name="datum" />
                </Form.Group>

                <Form.Group controlId="naziv">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control type="text" name="cijena" />
                </Form.Group>

                <hr />
                <Row>
                    <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.PREDSTAVA_PREGLED}>
                            Odustani
                        </Link>
                    </Col>

                    <Col>
                        <Button className="siroko" variant="primary" type="submit">
                            Dodaj
                        </Button>
                                        
                    
                    </Col>
                
                </Row>
            </Form>
        
        </Container>
    );
}