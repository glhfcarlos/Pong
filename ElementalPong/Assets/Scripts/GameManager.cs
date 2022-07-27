using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle player1Paddle;
    public Paddle player2Paddle;
    public Text player1ScoreText;
    public Text player2ScoreText;

    private int _player1Score;
    private int _player2Score;

    public void Player1Scores()
    {
        _player1Score++;

        this.player1ScoreText.text = _player1Score.ToString();
        ResetRound();
    }

    public void Player2Scores()
    {
        _player2Score++;
        
        this.player2ScoreText.text = _player2Score.ToString();
        ResetRound();
    }

    private void ResetRound()
    {
        this.player1Paddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }
}
