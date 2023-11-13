
import './App.css'
import AddQuote from './components/AddQuote'
import EditQuote from './components/EditQuote'
import QuoteList from './components/QuoteList'

function App() {

  return (
    <div>
      <h1 className='mb-[150px]'>React SPA Client</h1>
        <section className='flex w-[1300px] h-[900px] mx-auto'>
          <div className='w-[60%]'>
            <QuoteList/>
          </div>
          <div className='w-[40%]'>
            <div className='h-[50%]'>
              <AddQuote/>
            </div>
            <div className='h-[50%]'>
              {/* <EditQuote/> */}
            </div>
          </div>
      </section>
    </div>
  )
}

export default App
