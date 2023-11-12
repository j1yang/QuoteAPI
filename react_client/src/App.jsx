
import './App.css'
import AddQuote from './components/AddQuote'
import EditQuote from './components/EditQuote'
import QuoteList from './components/QuoteList'

function App() {

  return (
    <div>
      <h1>React SPA Client</h1>
      <QuoteList/>
      <AddQuote/>
      <EditQuote/>
    </div>
  )
}

export default App
