import React from 'react'
import Intro from './IntroComponents/Intro'
import NotFound from './NotFound'
import ProjectPage from './ProjectPageComponents/ProjectPage'
import LoadingPage from './LoadingPageComponents/LoadingPage'
import ErrorPage from './LoadingPageComponents/ErrorPage'
import BugsPage from './BugsPageComponents/BugsPage'
import LogsPage from './LogsPageComponent/LogsPage'
import {BrowserRouter,Route,Redirect,Switch} from 'react-router-dom'


export default function Router() {
    return (
        <div>
            <BrowserRouter>
                <Switch>
                    <Route exact path="/" component={Intro} />
                    <Route path="/Not-Found" component={NotFound} />
                    <Route path="/ProjectKey" component={ProjectPage} />
                    <Route path="/GetData" component={LoadingPage} />
                    <Route path="/Error" component={ErrorPage} />
                    <Route path="/Bugs" component={BugsPage} />
                    <Route path="/Logs" component={LogsPage} />
                    <Redirect to="/Not-Found"/>
                </Switch>
            </BrowserRouter>
        </div>
    )
}
