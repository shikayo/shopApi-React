import {Route,Routes} from 'react-router-dom'
import { AboutPage } from './Pages/AboutPage';
import { ProductsPage } from './Pages/ProductsPage';
import {Navigation} from './Components/Navigation'

function App() {
    return(
      <>
      <Navigation/>
      <Routes>
        <Route path='/' element={<ProductsPage/>}></Route>
        <Route path='/about' element={<AboutPage/>}></Route>
      </Routes>
      </>
    )
}

export default App;
