import { useState } from 'react'
import reactLogo from './assets/react.svg'
import mojLogo from '/vite.svg'
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavBar from './components/NavBar'
import { Route, Routes } from 'react-router-dom'
import { RoutesNames } from './constants'
import Pocetna from './pages/Pocetna'
import Predstave from './pages/predstave/Predstave'
import PredstaveDodaj from './pages/predstave/PredstaveDodaj'
import PredstavePromjena from './pages/predstave/PredstavePromjena'

function App() {


  return (
    <>
      <NavBar />
      <Routes>
        
        <Route path={RoutesNames.HOME} element={<Pocetna />} />
        <Route path={RoutesNames.PREDSTAVA_PREGLED} element={<Predstave />} />
        <Route path={RoutesNames.PREDSTAVA_NOVA} element={<PredstaveDodaj />} />
        <Route path={RoutesNames.PREDSTAVA_PROMJENI} element={<PredstavePromjena />} />
     
      </Routes>
    </>
  )
}

export default App
